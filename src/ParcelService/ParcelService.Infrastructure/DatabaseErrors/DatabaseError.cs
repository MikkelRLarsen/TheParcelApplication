using System;
using System.Collections.Generic;
using System.Text;
using ParcelService.Domain.Entities;
using Shared.ResultPattern;

namespace ParcelService.Infrastructure.DatabaseErrors
{
    public static class DatabaseError
    {
        public static Error DatabaseCreateError(Parcel parcel) =>
            Error.Failure("Database.Error", $"Unexpected error when creating Parcel with Id:{parcel.Id} & TrackingNumber{parcel.Tracking}");

        public static Error DatabaseSaveChangesError() =>
            Error.Failure("Database.Error", "Unexpected error when saving changes to databasen");
    }
}
