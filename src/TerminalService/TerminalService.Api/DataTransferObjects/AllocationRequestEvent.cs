using TerminalService.Facade.DataTransferObjects;

namespace TerminalService.Api.DataTransferObjects
{
	public sealed record AllocationRequestEvent
	{
		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }

		public AllocateRequest Map()
		{
			return new AllocateRequest(
				trackingNumber: TrackingNumber,
				terminalId: TerminalId);
		}
	}
}
