namespace RoutingService.Api.DataTransferObjects
{
	public sealed record AllocationReceivedEvent
	{
		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }

		public Facade.DataTransferObjects.AllocationReceivedEvent Map()
		{
			return new Facade.DataTransferObjects.AllocationReceivedEvent(
				trackingNumber: TrackingNumber,
				terminalId: TerminalId);
		}
	}
}
