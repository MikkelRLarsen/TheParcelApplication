using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoutingService.UseCase.InfrastructureInterfaces.Contracts
{
	public record AllocateRequestV1
	{
		[SetsRequiredMembers]
		public AllocateRequestV1(Guid trackingNumber, IEnumerable<Guid> terminals, int priority)
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
