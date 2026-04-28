using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
{
	public sealed record Region
	{
		public Region(string country, string mainRegion, string subRegion)
		{
			Country = country;
			MainRegion = mainRegion;
			SubRegion = subRegion;
		}

		public string Country { get; init; } = null!;
		public string MainRegion { get; init; } = null!;
		public string SubRegion { get; init; } = null!;
	}
}
