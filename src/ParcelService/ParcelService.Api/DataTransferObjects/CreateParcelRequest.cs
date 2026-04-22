using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record CreateParcelRequest
    {
		public decimal Weight { get; private set; }
		public int Priority { get; private set; }
		public Party Receiver { get; private set; }
		public Party Sender { get; private set; }


		public Facade.DataTransferObjects.CreateParcelCommandDto Map()
        {
            return new Facade.DataTransferObjects.CreateParcelCommandDto(
                weight: this.Weight,
                priority: this.Priority,
                receiver: this.Receiver.Map(),
                sender: this.Sender.Map());
        }
    }    
}
