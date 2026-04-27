using RoutingService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.GraphEntities
{
	public sealed record GraphEdge<T> where T : Entity
	{
		public GraphEdge(int weight, Guid toEntityId)
		{
			Weight = weight;
			ToEntityId = toEntityId;
		}

		public int Weight { get; init; }
		public Guid ToEntityId { get; init; }
	}
}
