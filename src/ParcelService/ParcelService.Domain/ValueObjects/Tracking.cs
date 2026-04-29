using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record Tracking
    {
        public required Guid TrackingNumber { get; init; }
        public required TrackingStatus Status { get; init; }

        [SetsRequiredMembers]
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
