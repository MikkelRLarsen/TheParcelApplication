using AllocationService.Domain;
using AllocationService.UseCase.Contracts;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.InfrastructureInterfaces
{
	public interface ICacheHandler
	{
		public Task<Result> CreateAsync(TerminalCacheState terminal);
		public Task<ResultT<TerminalCacheState>> GetAsync(Guid terminalId);
		public Task<Result> UpdateAsync(TerminalCacheState terminal);
	}
}
