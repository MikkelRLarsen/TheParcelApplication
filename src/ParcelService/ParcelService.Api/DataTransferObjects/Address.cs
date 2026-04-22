using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ParcelService.Facade.DataTransferObjects;

namespace ParcelService.Api.DataTransferObjects
{
    public record Address
    {
        public string Street { get; init; }
        public string HouseNumber { get; init; }
        public string City { get; init; }
        public string ZipCode { get; init; }
        public string Country { get; init; }

        public ParcelService.Facade.DataTransferObjects.Address Map()
        {
            return new Facade.DataTransferObjects.Address(
                street: this.Street,
                houseNumber: this.HouseNumber,
                city: this.City,
                zipCode: this.ZipCode,
                country: this.Country);
        }
    }  
}
