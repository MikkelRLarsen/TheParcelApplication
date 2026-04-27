using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Facade.DataTransferObjects
{
	public sealed record Terminal
	{
		public Guid TerminalId { get; init; }
		public Terminal(Guid terminalId)
		{
			TerminalId = terminalId;
		}
	}
}
