namespace TerminalService.Api.DataTransferObjects
{
	public sealed record TerminalCapacityRequest
	{
		public required Guid TerminalId { get; init; }

		public Facade.UpdateTerminalCapacity Map()
		{
			return new Facade.UpdateTerminalCapacity(TerminalId);
		}
	}
}
