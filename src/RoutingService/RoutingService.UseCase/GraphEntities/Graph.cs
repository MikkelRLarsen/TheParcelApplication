using RoutingService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.GraphEntities
{
	public sealed record Graph<T> where T : Entity
	{
		public Graph(GraphNode<T>[] graphNodes)
		{
			GraphNodes = graphNodes;
		}

		public GraphNode<T>[] GraphNodes { get; init; }
	}
}
