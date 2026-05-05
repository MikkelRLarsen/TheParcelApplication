using RoutingService.Domain;
using RoutingService.UseCase.RoutingAlgoritme;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoutingService.Infrastructure.Workflow
{
	internal static class DaprWorkflowExtensions
	{
		public static DaprWorkflowRoutePath ToRoutePath(this IRoutePath routePath)
		{
			return new DaprWorkflowRoutePath
			(
				terminal: routePath.Terminal.Id,
				nextPotentielTerminals: routePath.NextPotentielTerminals.Select(ToRoutePath).ToList()
			);
		}
	}

	public record DaprWorkflowRoutePath
	{
		[SetsRequiredMembers]
		public DaprWorkflowRoutePath(Guid terminal, List<DaprWorkflowRoutePath> nextPotentielTerminals)
		{
			Terminal = terminal;
			NextPotentielTerminals = nextPotentielTerminals;
		}

		public required Guid Terminal { get; init; }
		public required List<DaprWorkflowRoutePath> NextPotentielTerminals { get; init; }
	}
}
