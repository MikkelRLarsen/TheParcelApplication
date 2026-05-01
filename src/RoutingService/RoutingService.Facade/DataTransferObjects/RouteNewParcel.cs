using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
{
	public sealed record RouteNewParcel
	{
		[SetsRequiredMembers]
		public RouteNewParcel(Guid trackingNumber, Guid senderTerminal, Guid receiverTerminal, int priority)
		{
			TrackingNumber = trackingNumber;
			SenderTerminal = senderTerminal;
			ReceiverTerminal = receiverTerminal;
			Priority = priority;
		}

		public required Guid TrackingNumber { get; init; }
		public required Guid SenderTerminal { get; init; }
		public required Guid ReceiverTerminal { get; init; }
		public required int Priority { get; init; }
	}
}
