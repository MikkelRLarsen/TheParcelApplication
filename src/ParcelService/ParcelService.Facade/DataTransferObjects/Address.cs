using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public record Address
	{
		public required string Street { get; init; }
		public required string HouseNumber { get; init; }
		public required string City { get; init; }
		public required string ZipCode { get; init; }
		public required string Country { get; init; }

		[SetsRequiredMembers]
		public Address(string street, string houseNumber, string city, string zipCode, string country)
		{
			Street = street;
			HouseNumber = houseNumber;
			City = city;
			ZipCode = zipCode;
			Country = country;
		}
	}
}
