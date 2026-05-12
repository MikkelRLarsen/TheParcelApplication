using AllocationService.Domain;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.QueueFactories
{
	public sealed class TerminalQueue : IQueueTerminal
	{
		private readonly MinHeap<Terminal> _heap = new();
		public ResultT<Terminal> Dequeue()
		{
			return _heap.Dequeue();
		}

		public Result Enqueue(int priority, Terminal terminal)
		{
			_heap.Enqueue(priority, terminal);
			return Result.Success();
		}

		public ResultT<Terminal> Peek()
		{
			var result = _heap.Peek();
			return result;
		}
	}
}
