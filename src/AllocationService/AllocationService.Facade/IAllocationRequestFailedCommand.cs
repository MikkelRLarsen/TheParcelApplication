using AllocationService.Facade.DataTransferObjects;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.Facade
{
	public interface IAllocationRequestFailedCommand
	{
		public Task<Result> HandleAsync(AllocationRequestFailed allocationRequestFailed);
	}
}
