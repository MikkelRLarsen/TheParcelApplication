using Shared.ResultPattern;

namespace TerminalService.Facade
{
	public interface IUpdateTerminalCapacityQuery
	{
		public Task<Result> HandleAsync(UpdateTerminalCapacity updateTerminalCapacity);
	}
}
