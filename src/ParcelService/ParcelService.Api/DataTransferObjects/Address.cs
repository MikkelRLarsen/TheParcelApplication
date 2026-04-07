using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record Address(
    string Street,
    string HouseNumber,
    string City,
    string ZipCode,
    string Country
    );
}
