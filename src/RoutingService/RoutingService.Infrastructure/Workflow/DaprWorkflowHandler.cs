using Dapr.Workflow;
using RoutingService.Facade;
using RoutingService.Facade.DataTransferObjects;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.RoutingAlgoritme;

namespace RoutingService.Infrastructure.Workflow
{
	public sealed class DaprWorkflowHandler : ISagaStarter, ISagaRaiseEvent
	{
		private readonly DaprWorkflowClient _client;

		public DaprWorkflowHandler(DaprWorkflowClient client)
		{
			_client = client;
		}

		public async Task RaiseSagaEvent(AllocationReceivedEvent recievedEvent)
		{
			await _client.RaiseEventAsync(recievedEvent.TrackingNumber.ToString(), RoutingWorkflow.ExternalEventName, recievedEvent.TerminalId);
		}

		public async Task StartAllocateSaga(Guid trackingNumber, IRoutePath routePath, int priority)
		{
			var input = new RoutingWorkflowInput(trackingNumber, routePath, priority);

			await _client.ScheduleNewWorkflowAsync(nameof(RoutingWorkflow), trackingNumber.ToString(), input);
		}
	}
}
