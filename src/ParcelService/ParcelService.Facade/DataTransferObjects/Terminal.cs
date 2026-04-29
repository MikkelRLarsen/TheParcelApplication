using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public sealed record Terminal
	{
		[SetsRequiredMembers]
		public Terminal(Guid id, Region region)
		{
			Id = id;
			Region = region;
		}

		public required Guid Id { get; init; }
		public required Region Region { get; init; } = null!;
	}
}
