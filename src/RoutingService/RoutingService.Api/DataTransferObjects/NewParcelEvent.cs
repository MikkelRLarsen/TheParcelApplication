namespace RoutingService.Api.DataTransferObjects
{
	public record NewParcelEvent
	{
		public required Guid TrackingNumber { get; init; }
		public required Terminal Sender { get; init; }
		public required Terminal Receiver { get; init; }
		public required int Priority { get; init; }

		public Facade.DataTransferObjects.RouteNewParcel Map()
		{
			return new Facade.DataTransferObjects.RouteNewParcel(
				trackingNumber: TrackingNumber,
				sender: Sender.Map(),
				receiver: Receiver.Map(),
				priority: Priority);
		}
	}
}
