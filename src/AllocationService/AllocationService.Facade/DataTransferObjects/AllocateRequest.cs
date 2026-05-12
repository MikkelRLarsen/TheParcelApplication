using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;

namespace AllocationService.Facade.DataTransferObjects
{
	public record AllocateRequest
	{
		[SetsRequiredMembers]
		public AllocateRequest(Guid trackingNumber, IEnumerable<Guid> terminals, int priority)
		{
			TrackingNumber = trackingNumber;
			Terminals = terminals;
			Priority = priority;
		}

		public required Guid TrackingNumber { get; init; }
		public required IEnumerable<Guid> Terminals { get; init; }
		public required int Priority { get; init; }
	}
}
