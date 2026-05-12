using AllocationService.Domain;
using AllocationService.Infrastructure.InfrastructureErros;
using AllocationService.UseCase.Contracts;
using AllocationService.UseCase.InfrastructureInterfaces;
using Dapr.Client;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.Infrastructure.External
{
	public sealed partial class DaprStatestoreHandler : ICacheHandler
	{
		private const string _daprstatestore = "daprstatestore";
		private readonly DaprClient _daprClient;

		public DaprStatestoreHandler(DaprClient daprClient)
		{
			_daprClient = daprClient;
		}

		public async Task<Result> CreateAsync(TerminalCacheState terminal)
		{
			try
			{
				await _daprClient.SaveStateAsync<TerminalCacheState>(
					storeName: _daprstatestore,
					key: terminal.Id.ToString(),
					value: terminal);

				return Result.Success();
			}
			catch (Exception)
			{
				return CacheError.CreatingError(terminal.Id);
			}
		}

		public async Task<ResultT<TerminalCacheState>> GetAsync(Guid terminalId)
		{
			try
			{
				TerminalCacheState? terminal = await _daprClient
					.GetStateAsync<TerminalCacheState>(
						storeName: _daprstatestore,
						key: terminalId.ToString());

				return terminal is not null ? 
					terminal :
					CacheError.NotFound(terminalId);
			}
			catch (Exception)
			{
				return CacheError.GetError(terminalId);
			}
		}

		public async Task<Result> UpdateAsync(TerminalCacheState terminal)
		{
			try
			{
				await _daprClient.SaveStateAsync<TerminalCacheState>(
					storeName: _daprstatestore,
					key: terminal.Id.ToString(),
					value: terminal);

				return Result.Success();
			}
			catch (Exception)
			{
				return CacheError.UpdateError(terminal.Id);
			}
		}
	}
}
