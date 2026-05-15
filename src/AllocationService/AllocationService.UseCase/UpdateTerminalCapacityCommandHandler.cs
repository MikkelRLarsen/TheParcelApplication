using AllocationService.Domain;
using AllocationService.Facade;
using AllocationService.Facade.DataTransferObjects;
using AllocationService.UseCase.Contracts;
using AllocationService.UseCase.InfrastructureInterfaces;
using AllocationService.UseCase.QueueFactories;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase
{
	public sealed class UpdateTerminalCapacityCommandHandler : IUpdateTerminalCapacityCommand
	{
		private readonly ICacheHandler _cacheHandler;
		private readonly IQueueFactory _queueFactory;
		private readonly IAllocateRequestCommand _allocateRequestCommand;

		public UpdateTerminalCapacityCommandHandler(ICacheHandler cacheHandler, IQueueFactory queueFactory, IAllocateRequestCommand allocateRequestCommand)
		{
			_cacheHandler = cacheHandler;
			_queueFactory = queueFactory;
			_allocateRequestCommand = allocateRequestCommand;
		}

		public async Task<Result> HandleAsync(UpdateTerminalCapacity updateTerminalCapacity)
		{
			TerminalCacheState terminal = new TerminalCacheState(
				id: updateTerminalCapacity.TerminalId,
				capacity: updateTerminalCapacity.TerminalCapacity);

			Result cacheResult = await _cacheHandler.UpdateAsync(terminal);
			if (cacheResult.Status is ResultStatus.Failure)
				return cacheResult;

			ResultT<IQueueTerminal> queueResult = await _queueFactory.GetAsync(updateTerminalCapacity.TerminalId);
			if (queueResult.Status is ResultStatus.Failure)
				return queueResult;

			// Current dequeue strategy. Should be revisited later
			IQueueTerminal queue = queueResult.Value;
			for (int i = 0; i < updateTerminalCapacity.TerminalCapacity; i++)
			{
				ResultT<AllocationQueueContract> allocationResult = queue.Dequeue();
				if (allocationResult.Status is ResultStatus.Failure)
					return allocationResult;

				AllocationQueueContract allocation = allocationResult.Value;

				var allocateResult = await _allocateRequestCommand.HandleAsync(new AllocateRequest(
					trackingNumber: allocation.TrackingNumber,
					terminals: Enumerable.Repeat(allocation.TerminalId, 1),
					priority: allocation.Priority));

				if (allocateResult.Status is ResultStatus.Failure)
					return allocateResult;
			}

			return Result.Success();
		}
	}
}
