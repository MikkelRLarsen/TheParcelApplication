using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Domain.ValueObjects
{
    public record Party
    {
        public required Terminal Terminal { get; init; } = null!;
        public required PersonInfo PersonalInformation { get; init; } = null!;

		[SetsRequiredMembers]
		private Party() { }

		[SetsRequiredMembers]
		public Party(Terminal terminal, PersonInfo personalInformation)
		{
			Terminal = terminal;
			PersonalInformation = personalInformation;
		}
	}
}
