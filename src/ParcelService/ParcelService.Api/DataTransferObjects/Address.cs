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
                Street: this.Street,
                HouseNumber: this.HouseNumber,
                City: this.City,
                ZipCode: this.ZipCode,
                Country: this.Country);
        }
    }  
}
