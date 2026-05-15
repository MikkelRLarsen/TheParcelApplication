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
			try
			{
				return _heap.Dequeue();
			}
			catch (Exception ex)
			{
				return Error.Failure("Queue.Error", ex.Message);
			}
		}

		public Result Enqueue(AllocationQueueContract contract)
		{
			_heap.Enqueue(contract.Priority, contract);
			return Result.Success();
		}

		public ResultT<AllocationQueueContract> Peek()
		{
			try
			{
				return _heap.Peek();
			}
			catch (Exception ex)
			{
				return Error.Failure("Queue.Error", ex.Message);
			}
		}
	}
}
