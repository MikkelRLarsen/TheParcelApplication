using System.Diagnostics.CodeAnalysis;

namespace TerminalService.Facade
{
	public sealed record UpdateTerminalCapacity
	{
		[SetsRequiredMembers]
		public UpdateTerminalCapacity(Guid terminalId)
		{
			TerminalId = terminalId;
		}

		public required Guid TerminalId { get; init; }
	}
}
