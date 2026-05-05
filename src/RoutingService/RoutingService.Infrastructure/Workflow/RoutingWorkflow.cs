using Dapr.Workflow;
using RoutingService.Domain;
using RoutingService.Facade;
using RoutingService.UseCase.RoutingAlgoritme;
using System;
using System.Collections.Generic;
using System.Text;
using static RoutingService.Infrastructure.Workflow.DaprWorkflowHandler;

namespace RoutingService.Infrastructure.Workflow
{
	public sealed class RoutingWorkflow : Workflow< RoutingWorkflowInput,RoutingWorkflowResult>
	{
		public const string ExternalEventName = "AllocationRecieved";

		public override async Task<RoutingWorkflowResult> RunAsync(WorkflowContext context, RoutingWorkflowInput input)
		{
			RingBuffer<DaprWorkflowRoutePath> queue = new RingBuffer<DaprWorkflowRoutePath>(5);
			queue.Enqueue(input.RoutePath);

			while (queue.Any())
			{
				DaprWorkflowRoutePath routePaths = queue.Dequeue()!;

				await context.CallActivityAsync<RequestAllocationActivityResult>
					(nameof(RequestAllocationActivity), 
					new RequestAllocationActivityInput(input.TrackingNumber, routePaths.NextPotentielTerminals, input.Priority));

				Guid terminalId;
				while (true)
				{
					terminalId = await context.WaitForExternalEventAsync<Guid>(ExternalEventName, TimeSpan.FromDays(1));
					if (routePaths.NextPotentielTerminals.Any(p => p.Terminal == terminalId))
						break;
				}

				DaprWorkflowRoutePath nextPath = routePaths.NextPotentielTerminals.First(p => p.Terminal == terminalId);

				if (nextPath.NextPotentielTerminals.Any())
					queue.Enqueue(nextPath);
			}

			Console.WriteLine($"Workflow for {input.TrackingNumber} completed");
			return new RoutingWorkflowResult(true, "Allocation Complete");
		}
	}

	public record RoutingWorkflowInput(Guid TrackingNumber, DaprWorkflowRoutePath RoutePath, int Priority);
	public record RoutingWorkflowResult(bool Success, string Message);
}
