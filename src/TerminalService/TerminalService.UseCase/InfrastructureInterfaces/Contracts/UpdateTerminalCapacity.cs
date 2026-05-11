using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TerminalService.UseCase.InfrastructureInterfaces.Contracts
{
	public sealed record UpdateTerminalCapacity
	{
		[SetsRequiredMembers]
		public UpdateTerminalCapacity(Guid terminalId, int terminalCapacity, DateTime dateTime)
		{
			TerminalId = terminalId;
			TerminalCapacity = terminalCapacity;
			DateTime = dateTime;
		}

		public required Guid TerminalId { get; init; }
		public required int TerminalCapacity { get; init; }
		public required DateTime DateTime { get; init; }
	}
}
