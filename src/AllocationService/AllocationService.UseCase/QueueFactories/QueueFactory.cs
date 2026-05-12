using AllocationService.Domain;
using Shared.ResultPattern;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.QueueFactories
{
	public sealed class QueueFactory : IQueueFactory
	{
		private readonly ConcurrentDictionary<Guid, IQueueTerminal> _dict = new();
		public async Task<ResultT<IQueueTerminal>> GetAsync(Guid terminalId)
		{
			var queue = _dict.GetOrAdd(
				key: terminalId,
				value: new TerminalQueue());

			if (queue is null)
				return Error.Failure("Factory.Error", "Factory could not Get or Create IQueueTerminal");

			return ResultT<IQueueTerminal>.Success(queue);
		}
	}
}
