using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record Party
    {
        public Terminal Terminal { get; init; } = null!;
        public PersonInfo PersonalInformation { get; init; } = null!;

		[SetsRequiredMembers]
		private Party() { }
		public Party(Terminal terminal, PersonInfo personalInformation)
		{
			Terminal = terminal;
			PersonalInformation = personalInformation;
		}
	}
}
