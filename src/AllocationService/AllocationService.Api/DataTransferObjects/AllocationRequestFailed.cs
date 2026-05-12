using System.Diagnostics.CodeAnalysis;

namespace AllocationService.Api.DataTransferObjects
{
	public sealed record AllocationRequestFailed
	{
		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }
	}
}
