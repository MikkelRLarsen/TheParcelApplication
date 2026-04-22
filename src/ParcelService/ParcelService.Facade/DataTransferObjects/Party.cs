using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public record Party
	{
		public Guid TerminalId { get; init; }
		public PersonInfo PersonalInformation { get; init; }

		public Party(Guid terminalId, PersonInfo personalInformation)
		{
			TerminalId = terminalId;
			PersonalInformation = personalInformation;
		}
	}
}
