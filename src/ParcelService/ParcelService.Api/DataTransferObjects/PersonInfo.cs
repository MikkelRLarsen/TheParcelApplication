using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record PersonInfo(
        string Name,
        Address Address
    );
}
