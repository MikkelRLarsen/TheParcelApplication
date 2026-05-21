using System.Diagnostics.CodeAnalysis;

namespace AllocationService.Facade.DataTransferObjects
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
