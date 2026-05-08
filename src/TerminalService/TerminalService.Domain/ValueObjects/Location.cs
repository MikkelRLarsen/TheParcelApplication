using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TerminalService.Domain.ValueObjects
{
	public sealed record Location
	{
		[SetsRequiredMembers]
		private Location() { }

		[SetsRequiredMembers]
		public Location(Region region, Address address)
		{
			Region = region;
			Address = address;
		}

		public required Region Region { get; init; } = null!;
		public required Address Address { get; init; } = null!;
	}
}
