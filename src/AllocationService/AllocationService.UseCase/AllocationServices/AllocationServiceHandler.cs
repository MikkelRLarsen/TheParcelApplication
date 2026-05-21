using AllocationService.Domain;
using AllocationService.UseCase.InfrastructureInterfaces;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.AllocationServices
{
	public sealed class AllocationServiceHandler : IAllocationService
	{
		private readonly IPublisher _publisher;
		private readonly ICacheHandler _cacheHandler;

		public AllocationServiceHandler(IPublisher publisher, ICacheHandler cacheHandler)
		{
			_publisher = publisher;
			_cacheHandler = cacheHandler;
		}

		public async Task<Result> AllocateAsync(Guid trackingNumber, Terminal terminal)
		{
			if (terminal.AllocationPossible is false)
				return Error.BadRequest("Not", "Possbile");

			terminal.Decrement();
			await _cacheHandler.UpdateAsync(terminal.ToCache());
			await _publisher.PublishAllocateParcelToTerminalAsync(new Contracts.ParcelToTerminalContract(trackingNumber, terminal.Id));

			return Result.Success();
		}
	}
}
