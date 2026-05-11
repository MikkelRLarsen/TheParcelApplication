using RoutingService.UseCase.InfrastructureInterfaces.Contracts;
using Shared.ResultPattern;

namespace RoutingService.UseCase.InfrastructureInterfaces
{
	public interface IPublisher
	{
		public Task<Result> PublishAllocationRequest(AllocateRequestV1 request);
	}
}
