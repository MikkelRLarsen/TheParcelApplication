using AllocationService.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AllocationService.UseCase.Contracts
{
	public sealed record TerminalServiceState
	{
		[SetsRequiredMembers]
		public TerminalServiceState(Guid id, int capacity)
		{
			Id = id;
			Capacity = capacity;
		}

		public required Guid Id { get; init; }
		public required int Capacity { get; init; }
	}
}
