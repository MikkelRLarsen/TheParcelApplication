using System.Diagnostics.CodeAnalysis;

namespace AllocationService.UseCase.Contracts
{
	public sealed record AllocationQueueContract
	{
		[SetsRequiredMembers]
		public AllocationQueueContract(Guid trackingNumber, Guid terminalId, int priority)
		{
			TrackingNumber = trackingNumber;
			TerminalId = terminalId;
			Priority = priority;
		}

		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }
		public required int Priority { get; init; }
	}
	
}
