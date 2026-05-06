using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
	public sealed record Terminal
	{
		[SetsRequiredMembers]
		public Terminal(Guid id)
		{
			Id = id;
		}

		[SetsRequiredMembers]
		private Terminal() { }

		public required Guid Id { get; init; }
	}
}
