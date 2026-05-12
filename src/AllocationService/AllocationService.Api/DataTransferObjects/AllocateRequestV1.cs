using AllocationService.Facade.DataTransferObjects;
using System.Diagnostics.CodeAnalysis;

namespace AllocationService.Api.DataTransferObjects
{
	public record AllocateRequestV1
	{
		public required Guid TrackingNumber { get; init; }
		public required IEnumerable<Guid> Terminals { get; init; }
		public required int Priority { get; init; }

		public AllocateRequest Map()
		{
			return new AllocateRequest(
				trackingNumber: TrackingNumber,
				terminals: Terminals,
				priority: Priority);
		}
	}
}
