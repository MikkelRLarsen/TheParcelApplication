using RoutingService.Domain;
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
		public static DijkstraResult CalculateDijstra<T>(this Graph graph, Guid startId, Guid needleId)
		{
			// Before
			MinHeap<Guid> heap = new MinHeap<Guid>();
			Dictionary<Guid, DijkstraNode> dict = new Dictionary<Guid, DijkstraNode>();

			foreach (Terminal node in graph.GraphNodes)
			{
				DijkstraNode dNode = new(
					node: node,
					pathDistance: node.Id == startId ? 0 : int.MaxValue);

				heap.Enqueue(dNode.pathDistance, node.Id);
				dict.Add(node.Id, dNode);
			}

			// Edge case
			if (startId == needleId)
			{
				if (!dict.ContainsKey(startId))
					throw new InvalidOperationException("Start node not found in graph");

				return new DijkstraResult(dict[startId].node);
			}

			// Do it
			while (heap.Any())
			{
				DijkstraNode? dNode = GetNextNode(heap, dict);
				if (dNode is null)
					break;

				dNode.visited = true;

				foreach (Edge edge in dNode.node.Edges)
				{
					DijkstraNode? edgeNode = dict.GetValueOrDefault(edge.To);
					if (edgeNode == null) throw new InvalidOperationException();

					int potentielWeight = edge.weight + dNode.pathDistance;

					if (potentielWeight <= edgeNode.pathDistance)
					{
						edgeNode.SetPrevNode(dNode.node.Id, potentielWeight);
						heap.Enqueue(edgeNode.pathDistance, edgeNode.node.Id);
					}
				}
			}

			// After
			if (!dict[needleId].prevNodes.Any()) throw new InvalidOperationException();

			return DijkstraResult.Recursion(
				dResultDict: new Dictionary<Guid, DijkstraResult>(),
				dNodeDict: dict,
				nextNodeId: needleId,
				currentNodeId: needleId,
				isNeedle: true)
				[startId];
		}

		private static DijkstraNode? GetNextNode(MinHeap<Guid> heap, Dictionary<Guid, DijkstraNode> dict)
		{
			while (heap.Any())
			{
				int pathD = heap.GetPeakQueueValue();

				if (pathD is int.MaxValue)
					return null;

				DijkstraNode? dNode = dict.GetValueOrDefault(heap.Dequeue());
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
