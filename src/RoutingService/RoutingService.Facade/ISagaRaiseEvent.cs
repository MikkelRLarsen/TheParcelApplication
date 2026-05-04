using RoutingService.Facade.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Facade
{
	public interface ISagaRaiseEvent
	{
		public Task RaiseSagaEvent(AllocationReceivedEvent recievedEvent);
	}
}
