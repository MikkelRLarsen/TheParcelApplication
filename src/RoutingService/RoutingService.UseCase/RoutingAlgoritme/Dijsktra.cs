using RoutingService.Domain;
using RoutingService.Domain.ValueObjects;
using RoutingService.UseCase.GraphEntities;
using RoutingService.UseCase.Heap;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RoutingService.UseCase.RoutingAlgoritme
{
	public class Dijsktra : IRouteAlgoritme
	{
		public ResultT<IRoutePath> Calculate(Graph graph, Guid startId, Guid needleId)
		{
			try
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

						int potentielWeight = edge.Weight + dNode.pathDistance;

						if (potentielWeight <= edgeNode.pathDistance)
						{
							edgeNode.SetPrevNode(dNode.node.Id, potentielWeight);
							heap.Enqueue(edgeNode.pathDistance, edgeNode.node.Id);
						}
					}
				}

				// After
				if (!dict[needleId].prevNodes.Any()) return Error.Failure("RouteError", "No possible route exist");

				return DijkstraResult.Recursion(
					dResultDict: new Dictionary<Guid, DijkstraResult>(),
					dNodeDict: dict,
					nextNodeId: needleId,
					currentNodeId: needleId,
					isNeedle: true)
					[startId];
			}
			catch (Exception)
			{

				return Error.Failure("RouteError", "Error occured while calculating path");
			}

		}

		private static DijkstraNode? GetNextNode(MinHeap<Guid> heap, Dictionary<Guid, DijkstraNode> dict)
		{
			while (heap.Any())
			{
				int pathD = heap.GetPeakQueueValue();

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
