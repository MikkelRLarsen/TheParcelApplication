using AllocationService.Facade.DataTransferObjects;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.Facade
{
	public interface IUpdateTerminalCapacityCommand
	{
		public Task<Result> HandleAsync(UpdateTerminalCapacity updateTerminalCapacity);
	}
}
