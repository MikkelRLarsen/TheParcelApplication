using ParcelService.Domain.Exceptions;
using ParcelService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ParcelService.Domain.Entities
{
    public class Parcel
    {
        public Guid Id { get; private set; }
        public Tracking Tracking { get; private set; }
        public decimal Weight { get; private set; }
        public int Priority { get; private set; }
        public Destination Destination { get; private set; }
        public PersonInfo Sender { get; private set; }
        public PersonInfo Receiver { get; private set; }

        private Parcel() { }

        public Parcel(Tracking tracking, decimal weight, int priority, Destination destination, PersonInfo sender, PersonInfo receiver)
        {
            Tracking = tracking;
            Weight = weight;
            Priority = priority;
            Destination = destination;
            Sender = sender;
            Receiver = receiver;

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
