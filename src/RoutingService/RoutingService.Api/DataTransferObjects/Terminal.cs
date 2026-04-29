namespace RoutingService.Api.DataTransferObjects
{
	public record Terminal
	{
		public required Guid TerminalId { get; init; }
		public required Region Region { get; init; }

		public Facade.DataTransferObjects.Terminal Map()
		{
			return new Facade.DataTransferObjects.Terminal(
				terminalId: TerminalId,
				region: Region.Map());
		}
	}
}
