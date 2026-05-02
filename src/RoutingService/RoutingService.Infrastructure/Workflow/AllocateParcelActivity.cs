using Dapr.Client;
using Dapr.Workflow;
using RoutingService.UseCase.RoutingAlgoritme;

namespace RoutingService.Infrastructure.Workflow
{
	public sealed class AllocateParcelActivity : WorkflowActivity<AllocateActivityInput, object?>
	{
		private readonly DaprClient _client;

		public AllocateParcelActivity(DaprClient client)
		{
			_client = client;
		}

		public override async Task<object?> RunAsync(WorkflowActivityContext context, AllocateActivityInput input)
		{
			await _client.PublishEventAsync("",""); // Publish Event via Service

			return default;
		}
	}

	public record AllocateActivityInput(IReadOnlyCollection<IRoutePath> Paths, int Priority);
}
