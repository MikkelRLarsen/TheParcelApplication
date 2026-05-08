using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.Domain.Entities;

namespace TerminalService.UseCase.UseCaseErrors
{
	public static class AllocationError
	{
		public static Error NoMoreRetires(Guid terminalId, Guid trackingNumber) =>
			Error.Failure("Logic.Error", $"The allocation request ran out of retries on Terminal with Id:{terminalId} with Parcel with TrackingNumber{trackingNumber}");
	}
}
