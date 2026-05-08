using ParcelService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.UseCase.InfrastructureInterfaces.Contracts
{
	public sealed record NewParcelEvent
	{

		[SetsRequiredMembers]
		public NewParcelEvent(Parcel parcel)
		{
			TrackingNumber = parcel.Tracking.TrackingNumber;
			SenderTerminal = parcel.Sender.Terminal.Id;
			ReceiverTerminal = parcel.Receiver.Terminal.Id;
			Priority = parcel.Priority;
		}

		public required Guid TrackingNumber { get; init; }

		public required Guid SenderTerminal { get; init; }

		public required Guid ReceiverTerminal { get; init; }

		public required int Priority { get; init; }
	}
}
