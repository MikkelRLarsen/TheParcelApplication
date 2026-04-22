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
        public Guid Id { get; init; }
        public Tracking Tracking { get; private set; } = null!;
        public decimal Weight { get; private set; }
        public int Priority { get; private set; }
        public Party Receiver { get; private set; } = null!;
        public Party Sender { get; private set; } = null!;


        [SetsRequiredMembers]
        private Parcel() { }

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
