using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TerminalService.UseCase.InfrastructureInterfaces.Contracts
{
	public sealed record UpdateTerminalCapacity
	{
		[SetsRequiredMembers]
		public UpdateTerminalCapacity(Guid terminalId, int terminalCapacity)
		{
			TerminalId = terminalId;
			TerminalCapacity = terminalCapacity;
		}

		public required Guid TerminalId { get; init; }
		public required int TerminalCapacity { get; init; }
	}
}
