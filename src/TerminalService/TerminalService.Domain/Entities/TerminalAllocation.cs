using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TerminalService.Domain.ValueObjects;

namespace TerminalService.Domain.Entities
{
	public sealed class TerminalAllocation // Used as Event Sourcing Data
	{
		[SetsRequiredMembers]
		public TerminalAllocation(Guid terminalId, Guid trackingNumber, int version)
		{
			TerminalId = terminalId;
			TrackingNumber = trackingNumber;
			Id = Guid.NewGuid();
			AllocationDate = new();
			Version = version;
		}

		public void SetNewVersion(int newVersion)
		{
			Version = newVersion;
		}

		public required Guid Id { get; init; }
		public required Guid TerminalId { get; init; }
		public required Guid TrackingNumber { get; init; }
		public required Date AllocationDate { get; init; }
		public int Version { get; private set; }
	}
}
