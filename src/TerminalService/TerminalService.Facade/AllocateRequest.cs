using System.Diagnostics.CodeAnalysis;

namespace TerminalService.Facade
{
	public sealed record AllocateRequest
	{
		[SetsRequiredMembers]
		public AllocateRequest(Guid trackingNumber, Guid terminalId)
		{
			TrackingNumber = trackingNumber;
			TerminalId = terminalId;
		}

		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }
	}
}
