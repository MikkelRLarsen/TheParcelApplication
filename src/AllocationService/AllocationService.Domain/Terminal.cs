using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AllocationService.Domain
{
	public sealed class Terminal
	{
		[SetsRequiredMembers]
		public Terminal(Guid id, int capacity)
		{
			Id = id;
			Capacity = capacity;
		}

		public required Guid Id { get; init; }
		public required int Capacity { get; init; }
	}
}
