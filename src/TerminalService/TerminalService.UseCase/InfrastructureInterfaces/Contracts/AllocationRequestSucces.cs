using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TerminalService.UseCase.InfrastructureInterfaces.Contracts
{
	public sealed record AllocationRequestSucces
	{
		[SetsRequiredMembers]
		public AllocationRequestSucces(Guid trackingNumber, Guid terminalId)
		{
			TrackingNumber = trackingNumber;
			TerminalId = terminalId;
		}

		public required Guid TrackingNumber { get; init; }
		public required Guid TerminalId { get; init; }
	}
}
