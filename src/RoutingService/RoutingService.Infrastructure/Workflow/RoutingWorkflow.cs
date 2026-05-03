using System;
using System.Collections.Generic;
using System.Text;
using Dapr.Workflow;
using RoutingService.Facade;
using RoutingService.UseCase.RoutingAlgoritme;
using static RoutingService.Infrastructure.Workflow.DaprWorkflowHandler;

namespace RoutingService.Infrastructure.Workflow
{
	public sealed class RoutingWorkflow : Workflow< RoutingWorkflowInput,RoutingWorkflowResult>
	{
		public override async Task<RoutingWorkflowResult> RunAsync(WorkflowContext context, RoutingWorkflowInput input)
		{
			RingBuffer<IRoutePath> queue = new RingBuffer<IRoutePath>(5);
			queue.Enqueue(input.RoutePath);

			while (queue.Any())
			{
				IRoutePath routePaths = queue.Dequeue()!;

				await context.CallActivityAsync<RequestAllocationActivityResult>
					(nameof(RequestAllocationActivity), 
					new RequestAllocationActivityInput(input.TrackingNumber, routePaths.NextPotentielTerminals, input.Priority));

				Guid terminalId = await context.WaitForExternalEventAsync<Guid>(EventType.AllocationRecieveds.ToString());
				
				IRoutePath nextPath = routePaths.NextPotentielTerminals.First(p => p.Terminal.Id == terminalId);

				if(nextPath.NextPotentielTerminals.Any())
					queue.Enqueue(nextPath);
			}

			return new RoutingWorkflowResult(true, "Allocation Complete");
		}
	}

	public record RoutingWorkflowInput(Guid TrackingNumber, IRoutePath RoutePath, int Priority);
	public record RoutingWorkflowResult(bool Success, string Message);
}
