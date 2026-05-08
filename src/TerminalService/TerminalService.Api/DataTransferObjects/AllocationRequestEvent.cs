namespace TerminalService.Api.DataTransferObjects
{
	public sealed record AllocationRequestEvent
	{
		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }

		public Facade.AllocateRequest Map()
		{
			return new Facade.AllocateRequest(
				trackingNumber: TrackingNumber,
				terminalId: TerminalId);
		}
	}
}
