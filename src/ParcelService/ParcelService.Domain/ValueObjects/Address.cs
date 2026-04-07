using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record Address
    {
        public string Street { get; init; }
        public string HouseNumber { get; init; }
        public string City { get; init; }
        public string ZipCode { get; init; }
        public string Country { get; init; }

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
