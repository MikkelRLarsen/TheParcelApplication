using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public record Party
	{
		public required Terminal Terminal { get; init; }
		public required PersonInfo PersonalInformation { get; init; }

		[SetsRequiredMembers]
		public Party(Terminal terminal, PersonInfo personalInformation)
		{
			Terminal = terminal;
			PersonalInformation = personalInformation;
		}
	}
}
