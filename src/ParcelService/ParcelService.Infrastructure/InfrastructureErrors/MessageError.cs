using ParcelService.Domain.Entities;
using ParcelService.UseCase.InfrastructureInterfaces.Contracts;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Infrastructure.InfrastructureErrors
{
    public class MessageError
    {
        public static Error MessagePublishError(NewParcelEvent newParcelEvent) =>
            Error.Failure("Message.Error", $"Unexpected error when publishing creating Parcel with TrackingNumber{newParcelEvent.TrackingNumber}");
    }
}
