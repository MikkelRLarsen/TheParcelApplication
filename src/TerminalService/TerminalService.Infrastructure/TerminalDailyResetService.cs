using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.Domain.Entities;
using TerminalService.UseCase.InfrastructureInterfaces;
using TerminalService.UseCase.InfrastructureInterfaces.Contracts;

namespace TerminalService.Infrastructure
{
	public sealed class TerminalDailyResetService : BackgroundService
	{
		private readonly IServiceScopeFactory _scopeFactory;

		public TerminalDailyResetService(IServiceScopeFactory scopeFactory)
		{
			_scopeFactory = scopeFactory;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				var delay = GetDelayUntilMidnightUtc();

				await Task.Delay(delay, stoppingToken);

				using var scope = _scopeFactory.CreateScope();

				var repo = scope.ServiceProvider.GetRequiredService<ITerminalRepository>();
				var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

				var terminalsResult = await repo.GetAllTerminalsAsync();

				if (terminalsResult.Status is not ResultStatus.Success)
					continue;

				IEnumerable<Terminal> terminals = terminalsResult.Value;
				var now = DateTime.UtcNow;
				foreach(Terminal terminal in terminals)
				{
					await publisher.PublishUpdateTerminalCapacityAsync(
						new UpdateTerminalCapacity(
							terminalId: terminal.Id, 
							terminalCapacity: terminal.DailyCapacity
							));
				}
			}
		}

		private static TimeSpan GetDelayUntilMidnightUtc()
		{
			var now = DateTime.UtcNow;
			var nextMidnight = now.Date.AddDays(1);
			return nextMidnight - now;
		}
	}
}
