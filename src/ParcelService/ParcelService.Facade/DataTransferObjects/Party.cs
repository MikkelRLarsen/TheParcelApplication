using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public record Party
	{
		public Terminal Terminal { get; init; }
		public PersonInfo PersonalInformation { get; init; }

		public Party(Terminal terminal, PersonInfo personalInformation)
		{
			Terminal = terminal;
			PersonalInformation = personalInformation;
		}
	}
}
