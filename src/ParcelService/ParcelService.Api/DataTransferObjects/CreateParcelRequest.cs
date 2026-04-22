using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Api.DataTransferObjects
{
    public record CreateParcelRequest
    {
		public required decimal Weight { get; init; }
		public required int Priority { get; init; }
		public required Party Receiver { get; init; }
		public required Party Sender { get; init; }


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
