using System;
using System.Collections.Generic;
using System.Text;
using Dapr.Workflow;
using RoutingService.UseCase.RoutingAlgoritme;
using static RoutingService.Infrastructure.Workflow.DaprWorkflowHandler;

namespace RoutingService.Infrastructure.Workflow
{
	public sealed class AllocateWorkflow : Workflow< AllocateWorkflowInput,AllocateResult>
	{
		public override async Task<AllocateResult> RunAsync(WorkflowContext context, AllocateWorkflowInput input)
		{
			RingBuffer<IRoutePath> queue = new RingBuffer<IRoutePath>(5);
			queue.Enqueue(input.RoutePath);

			while (queue.Any())
			{
				IRoutePath routePaths = queue.Dequeue()!;

				var activityResult = await context.CallActivityAsync<AllocateActivityResult>
					(nameof(AllocateParcelActivity), 
					new AllocateActivityInput(routePaths.NextPotentielTerminals, input.Priority));

				context.WaitForExternalEventAsync<string>()
				
				if (activityResult.RecievedPath.NextPotentielTerminals.Any())
					queue.Enqueue(activityResult.RecievedPath);
			}

			return new AllocateResult(true, "Allocation Complete");
		}
	}

	public record AllocateWorkflowInput(IRoutePath RoutePath, int Priority);
	public record AllocateResult(bool Success, string Message);
}
