using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.UseCase.InfrastructureInterfaces.Contracts;

namespace TerminalService.UseCase.InfrastructureInterfaces
{
	public interface IPublisher
	{
		public Task<Result> PublishAllocationRequestSucces(AllocationRequestSucces allocationRequestSucces);
		public Task<Result> PublishAllocationRequestFailed(AllocationRequestFailed allocationRequestFailed);
	}
}
