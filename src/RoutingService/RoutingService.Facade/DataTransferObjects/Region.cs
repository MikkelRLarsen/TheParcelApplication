using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
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

		public required string Country { get; init; }
		public required string MainRegion { get; init; }
		public required string SubRegion { get; init; } 
	}
}
