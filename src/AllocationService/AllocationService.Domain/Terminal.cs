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
		public int Capacity { get; private set; }

		public bool AllocationPossible => Capacity > 0;
		public void Decrement()
		{
			if (AllocationPossible)
				Capacity--;
			else
				throw new Exception();
		}
	}
}
