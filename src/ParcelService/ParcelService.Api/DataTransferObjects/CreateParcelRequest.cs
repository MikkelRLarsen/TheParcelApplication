using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record CreateParcelRequest
    {
        public decimal Weight { get; init; }
        public int Priority { get; init; }
        public Destination Destination { get; init; }
        public PersonInfo Sender { get; init; }
        public PersonInfo Receiver { get; init; }


        public Facade.DataTransferObjects.CreateParcelCommandDto Map()
        {
            return new Facade.DataTransferObjects.CreateParcelCommandDto(
                weight: this.Weight,
                priority: this.Priority,
                destination: this.Destination.Map(),
                sender: this.Sender.Map(),
                reciever: this.Receiver.Map());
        }

    }    
}
