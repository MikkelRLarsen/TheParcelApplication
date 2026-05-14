using AllocationService.Facade;
using AllocationService.Facade.DataTransferObjects;
using AllocationService.UseCase.Contracts;
using AllocationService.UseCase.InfrastructureInterfaces;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase
{
	public sealed class UpdateTerminalCapacityCommandHandler : IUpdateTerminalCapacityCommand
	{
		private readonly ICacheHandler _cacheHandler;

		public UpdateTerminalCapacityCommandHandler(ICacheHandler cacheHandler)
		{
			_cacheHandler = cacheHandler;
		}

		public async Task<Result> HandleAsync(UpdateTerminalCapacity updateTerminalCapacity)
		{
			TerminalCacheState terminal = new TerminalCacheState(
				id: updateTerminalCapacity.TerminalId,
				capacity: updateTerminalCapacity.TerminalCapacity);

			return await _cacheHandler.UpdateAsync(terminal);
		}
	}
}
