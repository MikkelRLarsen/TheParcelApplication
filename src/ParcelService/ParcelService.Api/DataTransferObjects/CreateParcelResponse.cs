using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record CreateParcelResponse(
        Guid TrackingNumber
    );
}
