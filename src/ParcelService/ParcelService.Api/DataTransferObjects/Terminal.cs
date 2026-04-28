using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
	public sealed record Terminal
	{
		public required Guid Id { get; init; }
		public required Region Region { get; init; }

		public ParcelService.Facade.DataTransferObjects.Terminal Map()
		{
			return new Facade.DataTransferObjects.Terminal(
				id: Id,
				region: Region.Map()
				);
		}
	}
}
