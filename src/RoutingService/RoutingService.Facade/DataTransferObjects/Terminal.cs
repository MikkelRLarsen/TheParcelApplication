using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
{
	public sealed record Terminal
	{
		public Guid TerminalId { get; init; }
		public Region Region { get; init; }
		public Terminal(Guid terminalId, Region region)
		{
			TerminalId = terminalId;
			Region = region;
		}
	}
}
