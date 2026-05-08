using Microsoft.EntityFrameworkCore;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.Domain.Entities;
using TerminalService.Infrastructure.InfrastructureErros;
using TerminalService.UseCase.InfrastructureInterfaces;

namespace TerminalService.Infrastructure.Repositories
{
	public sealed class TerminalRepository : ITerminalRepository
	{
		private readonly EFAppContext _context;

		public TerminalRepository(EFAppContext context)
		{
			_context = context;
		}

		public async Task<Result> AllocateParcelAsync(TerminalAllocation allocation)
		{
			try
			{
				_context.TerminalAllocations.Add(allocation);
				return Result.Success();
			}
			catch (Exception)
			{
				return DatabaseError.AllocateError(allocation);
			}
		}

		public async Task<ResultT<TerminalDayStatus>> GetAllocationStatusAsync(Guid terminalId, DateOnly date)
		{
			int? dailyCapcity = await _context.Terminals.Where(t => t.Id == terminalId).Select(t => t.DailyCapacity).FirstOrDefaultAsync();
			if (dailyCapcity is null)
				return DatabaseError.NotFound(terminalId);

			var from = date.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
			var to = from.AddDays(1);

			try
			{
				IEnumerable<TerminalAllocation> allocations = await _context.TerminalAllocations
					.Where(a => a.TerminalId == terminalId &&
								a.AllocationDate.DateTime >= from &&
								a.AllocationDate.DateTime < to)
					.ToListAsync();

				return new TerminalDayStatus(terminalId, date, (int)dailyCapcity, allocations);
			}
			catch (Exception)
			{
				return DatabaseError.DatabaseGetError(terminalId);
			}
		}

		public async Task<Result> SaveChangesAsync()
		{
			try
			{
				await _context.SaveChangesAsync();
				return Result.Success();
			}
			catch (Exception)
			{
				return DatabaseError.Concurrency();
			}
		}
	}
}
