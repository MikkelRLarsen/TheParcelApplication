using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TerminalService.Domain.ValueObjects
{
	public sealed record Region
	{
		[SetsRequiredMembers]
		public Region(string country, string mainRegion, string subRegion)
		{
			Country = country;
			MainRegion = mainRegion;
			SubRegion = subRegion;
		}

		[SetsRequiredMembers]
		private Region() { }

		public required string Country { get; init; } = null!;
		public required string MainRegion { get; init; } = null!;
		public required string SubRegion { get; init; } = null!;
	}
}
