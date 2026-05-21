using AllocationService.Domain;
using AllocationService.UseCase.Contracts;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.TerminalResolvers
{
	public interface ITerminalResolver
	{
		public Task<ResultT<Terminal>> GetAsync(Guid terminalId);
		public Task<Result> ForceUpdateAsync(Guid terminalId);
	}
}
