using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
{
	public sealed record Terminal
	{
		public required Guid TerminalId { get; init; }
		public required Region Region { get; init; }

		[SetsRequiredMembers]
		public Terminal(Guid terminalId, Region region)
		{
			TerminalId = terminalId;
			Region = region;
		}
	}
}
