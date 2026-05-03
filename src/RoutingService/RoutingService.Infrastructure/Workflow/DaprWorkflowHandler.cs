using Dapr.Workflow;
using RoutingService.F;
using RoutingService.Facade;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.RoutingAlgoritme;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Infrastructure.Workflow
{
	public sealed class DaprWorkflowHandler : ISagaStarter, ISagaRaiseEvent
	{
		private readonly DaprWorkflowClient _client;

		public DaprWorkflowHandler(DaprWorkflowClient client)
		{
			_client = client;
		}

		public async Task RaiseSagaEvent(Guid trackingNumber, EventType eventName, Guid eventData)
		{
			await _client.RaiseEventAsync(trackingNumber.ToString(), eventName.ToString(), eventData);
		}

		public async Task StartAllocateSaga(Guid trackingNumber, IRoutePath routePath, int priority)
		{
			var input = new RoutingWorkflowInput(trackingNumber, routePath, priority);

			await _client.ScheduleNewWorkflowAsync(nameof(RoutingWorkflow), trackingNumber.ToString(), input);
		}
	}
}
