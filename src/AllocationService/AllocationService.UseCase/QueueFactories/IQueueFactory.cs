using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.QueueFactories
{
	public interface IQueueFactory
	{
		/// <summary>
		/// Gets IQueueTerminal, if doesnt exist it creates
		/// </summary>
		/// <param name="terminalId"></param>
		/// <returns></returns>
		public Task<ResultT<IQueueTerminal>> GetAsync(Guid terminalId);
	}
}
