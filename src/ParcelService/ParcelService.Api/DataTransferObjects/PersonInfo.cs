using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record PersonInfo
    {
        public string Name { get; init; }
        public Address Address { get; init; }

        public ParcelService.Facade.DataTransferObjects.PersonInfo Map()
        {
            return new Facade.DataTransferObjects.PersonInfo(
                name: this.Name,
                address: this.Address.Map());
        }
    }    
}
