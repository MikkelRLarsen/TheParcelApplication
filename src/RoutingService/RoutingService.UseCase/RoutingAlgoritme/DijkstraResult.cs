using RoutingService.Domain.ValueObjects;
using RoutingService.UseCase.GraphEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingAlgoritme
{
	public sealed class DijkstraResult<T> where T : Entity
	{
		public DijkstraResult(GraphNode<T> entity)
		{
			Entity = entity;
		}

		public HashSet<DijkstraResult<T>> NextPotentielTermnials { get; private set; } = new HashSet<DijkstraResult<T>>();
		public GraphNode<T> Entity { get; private set; }

		public static Dictionary<Guid, DijkstraResult<T>> Recursion<T>(
			Dictionary<Guid, DijkstraResult<T>> dResultDict,
			Dictionary<Guid, DijkstraNode<T>> dNodeDict,
			Guid nextNodeId,
			Guid currentNodeId,
			bool isNeedle = false)
			where T : Entity
		{
			// Pre
			DijkstraNode<T> dNode = dNodeDict[currentNodeId];

			if (dResultDict.ContainsKey(currentNodeId) is false)
				dResultDict.Add(currentNodeId, new DijkstraResult<T>(dNode.node));

			// Recurse
			if (dNode.prevNodes.Any())
			{
				foreach (Guid nodeId in dNode.prevNodes)
				{
					Recursion(dResultDict, dNodeDict, currentNodeId, nodeId);
				}
			}

			// Post
			if (isNeedle is false)
			{
				DijkstraResult<T> dResult = dResultDict[currentNodeId];
				dResult.NextPotentielTermnials.Add(dResultDict[nextNodeId]);
			}

			return dResultDict;
		}
	}
}
