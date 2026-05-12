using AllocationService.Domain;
using AllocationService.Facade;
using AllocationService.Facade.DataTransferObjects;
using AllocationService.UseCase.AllocationServices;
using AllocationService.UseCase.InfrastructureInterfaces;
using AllocationService.UseCase.QueueFactories;
using AllocationService.UseCase.TerminalResolvers;
using Shared.ResultPattern;

namespace AllocationService.UseCase
{
	public sealed class AllocateRequestCommand : IAllocateRequestCommand
	{
		private readonly ITerminalResolver _terminalResolver;
		private readonly IQueueFactory _queueFactory;
		private readonly IAllocationService _allocationService;

		public AllocateRequestCommand(ITerminalResolver terminalResolver, IQueueFactory queueFactory, IAllocationService allocationService)
		{
			_terminalResolver = terminalResolver;
			_queueFactory = queueFactory;
			_allocationService = allocationService;
		}

		public async Task<Result> HandleAsync(AllocateRequest allocateRequest)
		{
			Terminal? terminalWithHighestCapacity = null;
			foreach(Guid terminalId in allocateRequest.Terminals)
			{
				ResultT<Terminal> resolverResult = await _terminalResolver.GetAsync(terminalId);
				if (resolverResult.Status is ResultStatus.Failure)
					continue;

				Terminal terminal = resolverResult.Value;

				// base case
				if (terminalWithHighestCapacity is null 
					|| terminal.Capacity > terminalWithHighestCapacity.Capacity)
					terminalWithHighestCapacity = terminal;
			}

			if (terminalWithHighestCapacity is null)
				return Error.BadRequest("BadRequest", "No found");

			if (terminalWithHighestCapacity.Capacity > 0)
				return await _allocationService.AllocateAsync(
					new Contracts.AllocationContract(
						allocateRequest.TrackingNumber, 
						terminalWithHighestCapacity.Id));
			else
			{
				ResultT<IQueueTerminal> factoryResult = await _queueFactory.GetAsync(terminalWithHighestCapacity.Id);
				if (factoryResult.Status is ResultStatus.Failure)
					return factoryResult;

				IQueueTerminal queue = factoryResult.Value;

				return queue.Enqueue(
					priority: allocateRequest.Priority,
					terminal: terminalWithHighestCapacity);
			}
		}
	}
}
