using AllocationService.Domain;
using AllocationService.UseCase.Contracts;
using Shared.ResultPattern;

namespace AllocationService.UseCase.QueueFactories
{
	public interface IQueueTerminal
	{
		public ResultT<AllocationQueueContract> Peek();
		public ResultT<AllocationQueueContract> Dequeue();
		public Result Enqueue(AllocationQueueContract contract);
	}
}
