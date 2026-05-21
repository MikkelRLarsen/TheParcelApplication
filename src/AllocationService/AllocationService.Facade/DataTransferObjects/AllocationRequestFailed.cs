using System.Diagnostics.CodeAnalysis;

namespace AllocationService.Facade.DataTransferObjects
{
	public sealed record AllocationRequestFailed
	{
		[SetsRequiredMembers]
		public AllocationRequestFailed(Guid trackingNumber, Guid terminalId)
		{
			TrackingNumber = trackingNumber;
			TerminalId = terminalId;
		}

		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }
	}
}
