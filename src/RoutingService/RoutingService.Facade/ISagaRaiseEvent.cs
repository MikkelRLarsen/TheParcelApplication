using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Facade
{
	public interface ISagaRaiseEvent
	{
		public Task RaiseSagaEvent(Guid trackingNumber, EventType eventName, Guid eventData);
	}

	public enum EventType
	{
		AllocationRecieveds
	}
}
