using RoutingService.Domain.ValueObjects;
using RoutingService.UseCase.GraphEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingAlgoritme
{
	public sealed class DijkstraNode<T> where T : Entity
	{
		public GraphNode<T> node { get; init; }
		public HashSet<Guid> prevNodes { get; private set; }
		public int pathDistance { get; private set; }
		public bool visited { get; set; }

		public DijkstraNode(GraphNode<T> node, int pathDistance)
		{
			this.node = node;
			prevNodes = new HashSet<Guid>();
			this.pathDistance = pathDistance;
			visited = false;
		}

		public void SetPrevNode(Guid nodeGuid, int weight)
		{
			if (weight < pathDistance)
			{
				prevNodes.Clear();
				prevNodes.Add(nodeGuid);
				pathDistance = weight;
			}
			else if (weight == pathDistance)
			{
				prevNodes.Add(nodeGuid);
			}
		}
	}
}
