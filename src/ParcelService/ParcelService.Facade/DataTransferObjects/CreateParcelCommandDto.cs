using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
    public record CreateParcelCommandDto
    {
		public CreateParcelCommandDto(decimal weight, int priority, Party receiver, Party sender)
		{
			Weight = weight;
			Priority = priority;
			Receiver = receiver;
			Sender = sender;
		}

		public decimal Weight { get; private set; }
		public int Priority { get; private set; }
		public Party Receiver { get; private set; }
		public Party Sender { get; private set; }
    }
}
