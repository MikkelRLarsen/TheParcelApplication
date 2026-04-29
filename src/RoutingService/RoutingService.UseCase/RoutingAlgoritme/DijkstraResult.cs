using RoutingService.Domain;
using RoutingService.Domain.ValueObjects;
using RoutingService.UseCase.GraphEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingAlgoritme
{
	public sealed class DijkstraResult
	{
		public DijkstraResult(Terminal entity)
		{
			Entity = entity;
		}

		public HashSet<DijkstraResult> NextPotentielTermnials { get; private set; } = new HashSet<DijkstraResult>();
		public Terminal Entity { get; private set; }

		public static Dictionary<Guid, DijkstraResult> Recursion(
			Dictionary<Guid, DijkstraResult> dResultDict,
			Dictionary<Guid, DijkstraNode> dNodeDict,
			Guid nextNodeId,
			Guid currentNodeId,
			bool isNeedle = false)
		{
			// Pre
			DijkstraNode dNode = dNodeDict[currentNodeId];

			if (dResultDict.ContainsKey(currentNodeId) is false)
				dResultDict.Add(currentNodeId, new DijkstraResult(dNode.node));

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
				DijkstraResult dResult = dResultDict[currentNodeId];
				dResult.NextPotentielTermnials.Add(dResultDict[nextNodeId]);
			}

			return dResultDict;
		}
	}
}
