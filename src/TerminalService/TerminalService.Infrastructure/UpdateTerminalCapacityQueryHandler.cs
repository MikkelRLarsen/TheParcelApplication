using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.Domain.Entities;
using TerminalService.Facade;
using TerminalService.UseCase.InfrastructureInterfaces;
using TerminalService.UseCase.InfrastructureInterfaces.Contracts;

namespace TerminalService.Infrastructure
{
	public sealed class UpdateTerminalCapacityQueryHandler : IUpdateTerminalCapacityQuery
	{
		private readonly ITerminalRepository _terminalRepository;
		private readonly IPublisher _publisher;

		public UpdateTerminalCapacityQueryHandler(ITerminalRepository terminalRepository, IPublisher publisher)
		{
			_terminalRepository = terminalRepository;
			_publisher = publisher;
		}

		public async Task<Result> HandleAsync(Facade.UpdateTerminalCapacity updateTerminalCapacity)
		{
			ResultT<TerminalDayStatus> projectionResult = await _terminalRepository
					.GetAllocationStatusAsync(updateTerminalCapacity.TerminalId, DateOnly.FromDateTime(DateTime.UtcNow));
			if (projectionResult.Status is ResultStatus.Failure)
				return projectionResult.Error!;

			TerminalDayStatus projection = projectionResult.Value;

			Result publishResult = await _publisher.PublishUpdateTerminalCapacityAsync(
				new UseCase.InfrastructureInterfaces.Contracts.UpdateTerminalCapacity(
					updateTerminalCapacity.TerminalId,
					projection.GetAvailableAmount,
					DateTime.UtcNow));
			return publishResult;
		}
	}
}
