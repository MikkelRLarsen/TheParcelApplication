using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public sealed record Terminal
	{
		public Terminal(Guid id, Region region)
		{
			Id = id;
			Region = region;
		}

		public Guid Id { get; init; }
		public Region Region { get; init; } = null!;
	}
}
