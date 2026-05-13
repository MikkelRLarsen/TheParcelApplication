using AllocationService.Domain;
using AllocationService.UseCase.Contracts;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.QueueFactories
{
	public sealed class TerminalQueue : IQueueTerminal
	{
		private readonly MinHeap<AllocationQueueContract> _heap = new();

		public ResultT<AllocationQueueContract> Dequeue()
		{
			return _heap.Dequeue();
		}

		public Result Enqueue(AllocationQueueContract contract)
		{
			_heap.Enqueue(contract.Priority, contract);
			return Result.Success();
		}

		public ResultT<AllocationQueueContract> Peek()
		{
			return _heap.Peek();
		}
	}
}
