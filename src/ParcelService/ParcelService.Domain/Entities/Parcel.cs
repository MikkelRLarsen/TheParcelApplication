using ParcelService.Domain.Exceptions;
using ParcelService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace ParcelService.Domain.Entities
{
    public class Parcel
    {
        public required Guid Id { get; init; }
        public required Tracking Tracking { get; init; } = null!;
        public required decimal Weight { get; init; }
        public required int Priority { get; init; }
        public required Party Receiver { get; init; } = null!;
        public required Party Sender { get; init; } = null!;


        [SetsRequiredMembers]
        private Parcel() { }

        [SetsRequiredMembers]
		public Parcel(decimal weight, int priority, Party receiver, Party sender)
		{
			Id = Guid.NewGuid();
			Tracking = new Tracking();
			Weight = weight;
			Priority = priority;
			Receiver = receiver;
			Sender = sender;

			Validate();
		}

		protected void Validate()
        {
            if (Weight < 0)
                throw new DomainException("Must have a Weight");

            if (Priority < 0)
                throw new DomainException("Must have a Priority");
        }
    }
}
