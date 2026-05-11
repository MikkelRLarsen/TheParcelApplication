using System;
using System.Collections.Generic;
using System.Text;
using Shared.ResultPattern;
using TerminalService.Domain.Entities;

namespace TerminalService.UseCase.InfrastructureInterfaces
{
	public interface ITerminalRepository
	{
		public Task<ResultT<TerminalDayStatus>> GetAllocationStatusAsync(Guid terminalId, DateOnly date);
		public Task<Result> AllocateParcelAsync(TerminalAllocation allocation);
		public Task<Result> SaveChangesAsync();
		public Task<ResultT<IEnumerable<Terminal>>> GetAllTerminalsAsync();
	}
}
