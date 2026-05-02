using Dapr.Workflow;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.RoutingAlgoritme;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Infrastructure.Workflow
{
	public sealed class DaprWorkflowHandler : ISagaStarter
	{
		private readonly DaprWorkflowClient _client;

		public DaprWorkflowHandler(DaprWorkflowClient client)
		{
			_client = client;
		}

		public async Task StartAllocateSaga(Guid trackingNumber, IRoutePath routePath, int priority)
		{
			var input = new AllocateWorkflowInput(routePath, priority);

			await _client.ScheduleNewWorkflowAsync(nameof(AllocateWorkflow), trackingNumber.ToString(), input);
			await _client.RaiseEventAsync(trackingNumber.ToString(), )
		}
	}
}
