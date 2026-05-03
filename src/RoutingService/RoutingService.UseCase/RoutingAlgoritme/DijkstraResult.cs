using RoutingService.Domain;
using RoutingService.Domain.ValueObjects;
using RoutingService.UseCase.GraphEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingAlgoritme
{
	public sealed class DijkstraResult : IRoutePath
	{
		public DijkstraResult(Terminal entity)
		{
			Terminal = entity;
			_nextPotentielTerminals = new HashSet<DijkstraResult>();
		}

		private HashSet<DijkstraResult> _nextPotentielTerminals;
		public Terminal Terminal { get; private set; }
		public IReadOnlyCollection<IRoutePath> NextPotentielTerminals => _nextPotentielTerminals;

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
				dResult._nextPotentielTerminals.Add(dResultDict[nextNodeId]);
			}

			return dResultDict;
		}
	}
}
