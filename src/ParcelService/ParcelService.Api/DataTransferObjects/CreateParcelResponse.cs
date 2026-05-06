using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Schema;

namespace ParcelService.Api.DataTransferObjects
{
    public record CreateParcelResponse
    {
        public required Guid TrackingNumber { get; init; }

        [SetsRequiredMembers]
        public CreateParcelResponse(Guid trackingNumber)
        {
            TrackingNumber = trackingNumber;
        }

        public static CreateParcelResponse MapResponse(Facade.DataTransferObjects.CreateParcelCommandResponse response)
        {
            return new CreateParcelResponse(
                trackingNumber: response.TrackingNumber);
        }
    }
}
