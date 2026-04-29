using RoutingService.Domain;
using RoutingService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.GraphEntities
{
	public sealed record Graph
	{
		public Graph(Terminal[] graphNodes)
		{
			GraphNodes = graphNodes;
		}

		public Terminal[] GraphNodes { get; init; }
	}
}
