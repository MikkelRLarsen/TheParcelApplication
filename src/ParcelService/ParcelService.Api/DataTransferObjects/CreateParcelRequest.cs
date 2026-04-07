using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record CreateParcelRequest(
        decimal Weight,
        int Priority,
        Destination Destination,
        PersonInfo Sender,
        PersonInfo Receiver
    );
}
