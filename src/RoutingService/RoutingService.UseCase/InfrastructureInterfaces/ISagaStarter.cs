using RoutingService.UseCase.RoutingAlgoritme;

namespace RoutingService.UseCase.InfrastructureInterfaces
{
	public interface ISagaStarter
	{
		public Task StartAllocateSaga(Guid trackingNumber, IRoutePath routePath, int priority);
	}
}
