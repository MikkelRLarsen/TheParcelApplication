using AllocationService.Domain;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.InfrastructureInterfaces
{
	public interface ICacheHandler
	{
		public Task<ResultT<bool>> CheckForCacheAsync(Guid terminalId);
		public Task<Result> CreateAsync(Terminal terminal);
		public Task<ResultT<int>> GetCapacityAsync(Guid terminalId);
		public Task<Result> UpdateAsync(Terminal terminal);
	}
}
