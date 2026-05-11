using Google.Api;
using Microsoft.EntityFrameworkCore;
using RoutingService.Domain;
using RoutingService.Infrastructure.DatabaseErrors;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.SpecificationPattern;
using Shared.ResultPattern;

namespace RoutingService.Infrastructure.Repositories
{
	public class TerminalRepository : ITerminalRepository
    {
        private readonly EFAppContext _context;

		public TerminalRepository(EFAppContext context)
		{
			_context = context;
		}

		public async Task<ResultT<IEnumerable<Terminal>>> LoadAllAsync(ISpecification<Terminal> spec)
		{
			var terminals = await spec
				.Apply(_context.Terminals.AsNoTracking())
				.ToArrayAsync();

			if (!terminals.Any()) 
				return Error.NotFound("DATABASE", "No terminal found");

			var allowedIds = terminals
				.Select(t => t.Id)
				.ToHashSet();

			var edgeDict = await _context.Edges
				.Where(e =>
					allowedIds.Contains(e.From) &&
					allowedIds.Contains(e.To))
				.GroupBy(e => e.From)
				.ToDictionaryAsync(
					g => g.Key,
					g => g.ToHashSet()
				);

			foreach(var terminal in terminals)
			{
				terminal
					.SetEdges(edgeDict.TryGetValue(terminal.Id, out var edge) ? 
						edge : 
						Array.Empty<Edge>());

			}
			return terminals;
		}

		public async Task<ResultT<Terminal>> LoadAsync(Guid id)
		{
			var terminal = _context.Terminals.FirstOrDefault(t => t.Id == id);

			return terminal != null ? terminal : DatabaseError.NotFound(id);
		}
	}
}
