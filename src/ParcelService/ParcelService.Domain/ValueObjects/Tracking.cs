using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record Tracking
    {
        public Guid TrackingNumber { get; init; }
        public TrackingStatus Status { get; init; }

        public Tracking()
        {
            TrackingNumber = Guid.NewGuid();
            Status = TrackingStatus.Recieved;
        }
    }

    public enum TrackingStatus
    {
        Recieved, InRoute, Delivered
    }
}
