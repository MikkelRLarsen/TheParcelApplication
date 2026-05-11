using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TerminalService.Domain.ValueObjects
{
	public sealed record Address
	{
		[SetsRequiredMembers]
		private Address() { }

		[SetsRequiredMembers]
		public Address(City city, string street, int streetNumber)
		{
			City = city;
			Street = street;
			StreetNumber = streetNumber;
		}

		public required City City { get; init; } = null!;
		public required string Street { get; init; } = null!;
		public required int StreetNumber { get; init; }
	}
}
