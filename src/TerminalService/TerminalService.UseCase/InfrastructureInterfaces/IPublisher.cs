using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.UseCase.InfrastructureInterfaces.Contracts;

namespace TerminalService.UseCase.InfrastructureInterfaces
{
	public interface IPublisher
	{
		public Task<Result> PublishAllocationRequestSuccesAsync(AllocationRequestSucces allocationRequestSucces);
		public Task<Result> PublishAllocationRequestFailedAsync(AllocationRequestFailed allocationRequestFailed);
		public Task<Result> PublishUpdateTerminalCapacityAsync(UpdateTerminalCapacity updateTerminalCapacity);
	}
}
