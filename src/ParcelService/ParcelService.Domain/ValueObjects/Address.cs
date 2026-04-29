using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record Address
    {
        public required string Street { get; init; } = null!;
        public required string HouseNumber { get; init; } = null!;
        public required string City { get; init; } = null!;
        public required string ZipCode { get; init; } = null!; 
        public required string Country { get; init; } = null!;

        [SetsRequiredMembers]
        private Address() { }

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
