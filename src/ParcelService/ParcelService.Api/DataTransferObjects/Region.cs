using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
	public sealed record Region
	{
		public required string Country { get; init; }
		public required string MainRegion { get; init; }
		public required string SubRegion { get; init; }

		public ParcelService.Facade.DataTransferObjects.Region Map()
		{
			return new Facade.DataTransferObjects.Region(
				country: Country,
				mainRegion: MainRegion,
				subRegion: SubRegion
				);
		}
	}
}
