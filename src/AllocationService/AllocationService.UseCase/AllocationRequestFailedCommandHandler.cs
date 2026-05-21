using AllocationService.Facade;
using AllocationService.Facade.DataTransferObjects;
using AllocationService.UseCase.TerminalResolvers;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase
{
	public sealed class AllocationRequestFailedCommandHandler : IAllocationRequestFailedCommand
	{
		private readonly ITerminalResolver _terminalResolver;
		private readonly IAllocateRequestCommand _allocateRequestCommand;
		private const int _defaultRequeuePriority = 1; // Request should be cached later to reuse priority and potentiel terminals

		public AllocationRequestFailedCommandHandler(ITerminalResolver terminalResolver, IAllocateRequestCommand allocateRequestCommand)
		{
			_terminalResolver = terminalResolver;
			_allocateRequestCommand = allocateRequestCommand;
		}

		public async Task<Result> HandleAsync(AllocationRequestFailed allocationRequestFailed)
		{
			await _terminalResolver.ForceUpdateAsync(allocationRequestFailed.TerminalId);

			AllocateRequest allocateRequest = new AllocateRequest(
				trackingNumber: allocationRequestFailed.TrackingNumber,
				terminals: Enumerable.Repeat(allocationRequestFailed.TerminalId, 1),
				priority: _defaultRequeuePriority);

			return await _allocateRequestCommand.HandleAsync(allocateRequest);
		}
	}
}
