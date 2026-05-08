using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TerminalService.Domain.ValueObjects;

namespace TerminalService.Domain.Entities
{
	public sealed class Terminal
	{
		[SetsRequiredMembers]
		public Terminal(int dailyCapacity, TerminalType type, Location location)
		{
			Id = Guid.NewGuid();
			Type = type;
			DailyCapacity = dailyCapacity;
			Location = location;
		}

		[SetsRequiredMembers]
		private Terminal() { }

		public required Guid Id { get; init; }
		public required TerminalType Type { get; init; }
		public required int DailyCapacity { get; init; }
		public required Location Location { get; init; } = null!;
	}

	public enum TerminalType
	{
		Hub, PickupPoint, DistributionCenter
	}
}
