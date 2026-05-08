using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TerminalService.Domain.ValueObjects;

namespace TerminalService.Domain.Entities
{
	public sealed class TerminalDayStatus // Used as a projection for EventSourcing
	{
		public required Guid TerminalId { get; init; }
		public required Date Date { get; init;  }
		public required int TotalCapcity { get; init; }
		public required int CurrentReserved { get; init; }
		public bool ResevationPossible => CurrentReserved < TotalCapcity;
		public int GetNextVersion => CurrentReserved + 1;

		[SetsRequiredMembers]
		public TerminalDayStatus(Guid terminalId, Date date, int totalCapacity,IEnumerable<TerminalAllocation> allocations)
		{
			TerminalId = terminalId;
			Date = date;
			TotalCapcity = totalCapacity;
			CurrentReserved = allocations.Count();

			if (TotalCapcity < CurrentReserved) throw new InvalidOperationException("There is a overallocation");
		}
	}
}
