using AllocationService.Domain;
using AllocationService.UseCase.Contracts;
using Shared.ResultPattern;

namespace AllocationService.UseCase.QueueFactories
{
	public interface IQueueTerminal
	{
		public ResultT<Terminal> Peek();
		public ResultT<Terminal> Dequeue();
		public Result Enqueue(int priority, Terminal terminal);
	}
}
