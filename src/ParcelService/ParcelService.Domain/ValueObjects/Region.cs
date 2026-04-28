using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
	public sealed record Region
	{
		public Region(string country, string mainRegion, string subRegion)
		{
			Country = country;
			MainRegion = mainRegion;
			SubRegion = subRegion;
		}

		[SetsRequiredMembers]
		private Region() { }

		public string Country { get; init; } = null!;
		public string MainRegion { get; init; } = null!;
		public string SubRegion { get; init; } = null!;
	}
}
