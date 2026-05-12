using AllocationService.Domain;
using System.Diagnostics.CodeAnalysis;

namespace AllocationService.UseCase.Contracts
{
	public sealed record TerminalCacheState
	{
		[SetsRequiredMembers]
		public TerminalCacheState(Guid id, int capacity)
		{
			Id = id;
			Capacity = capacity;
		}

		public required Guid Id { get; init; }
		public required int Capacity { get; init; }
	}
}
