using RoutingService.Domain.ValueObjects;
using RoutingService.UseCase.GraphEntities;
using RoutingService.UseCase.Heap;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RoutingService.UseCase.RoutingAlgoritme
{
	public static class Dijsktra
	{
		public static DijkstraResult<T> CalculateDijstra<T>(this Graph<T> graph, Guid startId, Guid needleId) where T : Entity
		{
			// Before
			MinHeap<Guid> heap = new MinHeap<Guid>();
			Dictionary<Guid, DijkstraNode<T>> dict = new Dictionary<Guid, DijkstraNode<T>>();

			foreach (GraphNode<T> node in graph.GraphNodes)
			{
				DijkstraNode<T> dNode = new(
					node: node,
					pathDistance: node.Entity.Id == startId ? 0 : int.MaxValue);

				heap.Enqueue(dNode.pathDistance, node.Entity.Id);
				dict.Add(node.Entity.Id, dNode);
			}

			// Edge case
			if (startId == needleId)
			{
				if (!dict.ContainsKey(startId))
					throw new InvalidOperationException("Start node not found in graph");

				return new DijkstraResult<T>(dict[startId].node);
			}

			// Do it
			while (heap.Any())
			{
				DijkstraNode<T>? dNode = GetNextNode<T>(heap, dict);
				if (dNode is null)
					break;

				dNode.visited = true;

				foreach (GraphEdge<T> edge in dNode.node.Edges)
				{
					DijkstraNode<T>? edgeNode = dict.GetValueOrDefault(edge.ToEntityId);
					if (edgeNode == null) throw new InvalidOperationException();

					int potentielWeight = edge.Weight + dNode.pathDistance;

					if (potentielWeight <= edgeNode.pathDistance)
					{
						edgeNode.SetPrevNode(dNode.node.Entity.Id, potentielWeight);
						heap.Enqueue(edgeNode.pathDistance, edgeNode.node.Entity.Id);
					}
				}
			}

			// After
			if (!dict[needleId].prevNodes.Any()) throw new InvalidOperationException();

			return DijkstraResult<T>.Recursion(
				dResultDict: new Dictionary<Guid, DijkstraResult<T>>(),
				dNodeDict: dict,
				nextNodeId: needleId,
				currentNodeId: needleId,
				isNeedle: true)
				[startId];
		}

		private static DijkstraNode<T>? GetNextNode<T>(MinHeap<Guid> heap, Dictionary<Guid, DijkstraNode<T>> dict) where T : Entity
		{
			while (heap.Any())
			{
				int pathD = heap.GetPeakQueueValue();

				if (pathD is int.MaxValue)
					return null;

				DijkstraNode<T>? dNode = dict.GetValueOrDefault(heap.Dequeue());
				if (dNode == null) throw new InvalidOperationException();

				if (dNode.visited is true)
					continue;

				if (dNode.pathDistance == pathD)
					return dNode;
			}
			return null;
		}
	}
}
