using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public sealed record Terminal
	{
		[SetsRequiredMembers]
		public Terminal(Guid id)
		{
			Id = id;
		}

		public required Guid Id { get; init; }
	}
}
