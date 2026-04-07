using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record Tracking
    {
        public Guid TrackingNumber { get; init; }
        public TrackingStatus Status { get; init; }

        public Tracking(Guid trackingNumber, TrackingStatus status)
        {
            TrackingNumber = trackingNumber;
            Status = status;
        }
    }

    public enum TrackingStatus
    {
        Recieved, InRoute, Delivered
    }
}
