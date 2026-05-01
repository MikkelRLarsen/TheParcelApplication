using System.Diagnostics.CodeAnalysis;

namespace RoutingService.Api.DataTransferObjects
{
	public record NewParcelEvent
	{
		public required Guid TrackingNumber { get; init; }
		public required Guid SenderTerminal { get; init; }
		public required Guid ReceiverTerminal { get; init; }
		public required int Priority { get; init; }

		public Facade.DataTransferObjects.RouteNewParcel Map()
		{
			return new Facade.DataTransferObjects.RouteNewParcel(
				trackingNumber: TrackingNumber,
				senderTerminal: SenderTerminal,
				receiverTerminal: ReceiverTerminal,
				priority: Priority);
		}
	}
}
