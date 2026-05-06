using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.InfrastructureInterfaces
{
	public interface IPublisher
	{
		public Task<Result> PublishAllocationRequest(Guid trackingNumber, IEnumerable<Guid> terminals, int priority);
	}
}
