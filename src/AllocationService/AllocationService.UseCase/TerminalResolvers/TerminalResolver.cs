using AllocationService.Domain;
using AllocationService.UseCase.Contracts;
using AllocationService.UseCase.InfrastructureInterfaces;
using Shared.ResultPattern;

namespace AllocationService.UseCase.TerminalResolvers
{
	public sealed class TerminalResolver : ITerminalResolver
	{
		private readonly ICacheHandler _cacheHandler;
		private readonly ITerminalService _terminalService;

		public TerminalResolver(ICacheHandler cacheHandler, ITerminalService terminalService)
		{
			_cacheHandler = cacheHandler;
			_terminalService = terminalService;
		}

		public async Task<ResultT<Terminal>> GetAsync(Guid terminalId)
		{
			ResultT<TerminalCacheState> cacheResult = await _cacheHandler.GetAsync(terminalId);
			if (cacheResult.Status is ResultStatus.Success)
				return cacheResult.Value.ToDomain();

			ResultT<TerminalServiceState> terminalResult = await _terminalService.GetAsync(terminalId);
			if (terminalResult.Status is ResultStatus.Failure)
				return terminalResult.Error!;

			Terminal terminal = terminalResult.Value.ToDomain();
			TerminalCacheState cacheState = terminal.ToCache();
			await _cacheHandler.CreateAsync(cacheState);

			return terminal;
		}
	}
}
