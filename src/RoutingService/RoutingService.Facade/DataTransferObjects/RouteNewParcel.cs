using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
{
	public sealed record RouteNewParcel
	{
		public RouteNewParcel(Guid trackingNumber, Terminal sender, Terminal receiver, int priority)
		{
			TrackingNumber = trackingNumber;
			Sender = sender;
			Receiver = receiver;
			Priority = priority;
		}

		public Guid TrackingNumber { get; init; }
		public Terminal Sender { get; init; }
		public Terminal Receiver { get; init; }
		public int Priority { get; init; }
	}
}
