using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
{
	public sealed record RouteNewParcel
	{
		public RouteNewParcel(Guid trackingNumber, Terminal senderTerminal, Terminal receiverTerminal, int priority)
		{
			TrackingNumber = trackingNumber;
			SenderTerminal = senderTerminal;
			ReceiverTerminal = receiverTerminal;
			Priority = priority;
		}

		public Guid TrackingNumber { get; init; }
		public Terminal SenderTerminal { get; init; }
		public Terminal ReceiverTerminal { get; init; }
		public int Priority { get; init; }
	}
}
