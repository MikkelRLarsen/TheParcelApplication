using RoutingService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RoutingService.Domain
{
	public sealed class Edge
	{
		[SetsRequiredMembers]
		public Edge(Guid from, Guid to, int weight)
		{
			From = from;
			To = to;
			this.weight = weight;
		}

		public required Guid From { get; init; }
		public required Guid To { get; init; }
		public required int weight { get; init; }
	}
}
