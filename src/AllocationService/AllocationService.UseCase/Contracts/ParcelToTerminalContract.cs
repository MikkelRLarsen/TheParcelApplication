using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AllocationService.UseCase.Contracts
{
	public sealed record ParcelToTerminalContract
	{
		[SetsRequiredMembers]
		public ParcelToTerminalContract(Guid trackingNumber, Guid terminalId)
		{
			TrackingNumber = trackingNumber;
			TerminalId = terminalId;
		}

		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }
	}
}
