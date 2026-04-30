using ParcelService.Domain.Entities;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Infrastructure.InfrastructureErrors
{
    public class MessageError
    {
        public static Error MessagePublishError(Parcel parcel) =>
            Error.Failure("Message.Error", $"Unexpected error when publishing creating Parcel with Id:{parcel.Id} & TrackingNumber{parcel.Tracking}");
    }
}
