using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
    public record CreateParcelCommandDto
    {
		[SetsRequiredMembers]
		public CreateParcelCommandDto(decimal weight, int priority, Party receiver, Party sender)
		{
			Weight = weight;
			Priority = priority;
			Receiver = receiver;
			Sender = sender;
		}

		public required decimal Weight { get; init; }
		public required int Priority { get; init; }
		public required Party Receiver { get; init; }
		public required Party Sender { get; init; }
    }
}
