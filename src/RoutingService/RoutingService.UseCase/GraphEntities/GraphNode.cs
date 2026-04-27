using RoutingService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.GraphEntities
{
	public sealed class GraphNode<T> where T : Entity
	{
		public GraphNode(GraphEdge<T>[] edges, T entity)
		{
			Edges = edges;
			Entity = entity;
		}

		public GraphEdge<T>[] Edges { get; init; }
		public T Entity { get; init; }
	}
}
