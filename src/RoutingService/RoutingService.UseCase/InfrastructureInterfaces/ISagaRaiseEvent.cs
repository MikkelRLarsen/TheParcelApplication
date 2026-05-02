using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.InfrastructureInterfaces
{
	public interface ISagaRaiseEvent
	{
		public Task RaiseSagaEvent(Guid trackingNumber, string eventName, object eventData);
	}
}
