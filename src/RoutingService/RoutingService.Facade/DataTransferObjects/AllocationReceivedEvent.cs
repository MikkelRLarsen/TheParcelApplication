using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
{
	public sealed record AllocationReceivedEvent
	{
		[SetsRequiredMembers]
		public AllocationReceivedEvent(Guid trackingNumber, Guid terminalId)
		{
			TrackingNumber = trackingNumber;
			TerminalId = terminalId;
		}

		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }
	}
}
