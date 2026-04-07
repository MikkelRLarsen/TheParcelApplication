using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record Destination(
        string Region,
        string Terminal
    );
}
