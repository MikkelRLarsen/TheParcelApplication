using System.Diagnostics.CodeAnalysis;

namespace AllocationService.Api.DataTransferObjects
{
	public sealed record UpdateTerminalCapacity
	{
		public required Guid TerminalId { get; init; }
		public required int TerminalCapacity { get; init; }
	}
}
