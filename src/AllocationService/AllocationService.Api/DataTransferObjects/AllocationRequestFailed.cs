using System.Diagnostics.CodeAnalysis;

namespace AllocationService.Api.DataTransferObjects
{
	public sealed record AllocationRequestFailed
	{
		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }

		public Facade.DataTransferObjects.AllocationRequestFailed Map()
		{
			return new Facade.DataTransferObjects.AllocationRequestFailed(
				trackingNumber: TrackingNumber,
				terminalId: TerminalId);
		}
	}
}
