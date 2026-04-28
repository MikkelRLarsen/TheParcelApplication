namespace RoutingService.Api.DataTransferObjects
{
	public record NewParcelEvent
	{
		public required Guid TrackingNumber { get; init; }
		public required Terminal SenderTerminal { get; init; }
		public required Terminal ReceiverTerminal { get; init; }
		public required int Priority { get; init; }

		public Facade.DataTransferObjects.RouteNewParcel Map()
		{
			return new Facade.DataTransferObjects.RouteNewParcel(
				trackingNumber: TrackingNumber,
				senderTerminal: SenderTerminal.Map(),
				receiverTerminal: ReceiverTerminal.Map(),
				priority: Priority);
		}
	}
}
