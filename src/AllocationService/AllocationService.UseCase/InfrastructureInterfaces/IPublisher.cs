using AllocationService.UseCase.Contracts;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.InfrastructureInterfaces
{
	public interface IPublisher
	{
		public Task<Result> PublishAllocateParcelToTerminalAsync(ParcelToTerminalContract parcelToTerminalContract);
	}
}
