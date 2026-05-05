using Dapr.Client;
using Dapr.Workflow;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.RoutingAlgoritme;

namespace RoutingService.Infrastructure.Workflow
{
	public sealed class RequestAllocationActivity : WorkflowActivity<RequestAllocationActivityInput, RequestAllocationActivityResult>
	{
		private readonly IPublisher _publisher;

		public RequestAllocationActivity(IPublisher publisher)
		{
			_publisher = publisher;
		}

		public override async Task<RequestAllocationActivityResult> RunAsync(WorkflowActivityContext context, RequestAllocationActivityInput input)
		{
			IEnumerable<Guid> potentielTerminalId = input.Paths.Select(p => p.Terminal);

			await _publisher.PublishAllocationRequest(input.TrackingNumber, potentielTerminalId, input.Priority);

			return new RequestAllocationActivityResult(true);
		}
	}

	public record RequestAllocationActivityInput(Guid TrackingNumber, IReadOnlyCollection<DaprWorkflowRoutePath> Paths, int Priority);
	public record RequestAllocationActivityResult(bool Published);
}
