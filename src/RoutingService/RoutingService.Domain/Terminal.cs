using RoutingService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoutingService.Domain
{
	public sealed class Terminal
	{
		[SetsRequiredMembers]
		private Terminal() { }

		[SetsRequiredMembers]
		public Terminal(Guid id, Region region, TerminalType type)
		{
			Id = id;
			Region = region;
			Type = type;
		}

		public required Guid Id { get; init; }
		public required Region Region { get; init; } = null!;
		public required TerminalType Type { get; init; }
		public IReadOnlyCollection<Edge> Edges { get; private set; } = [];

		public void SetEdges(IEnumerable<Edge> edges)
		{
			if (edges.Any(e => e.From != Id || e.To == Id))
				throw new InvalidOperationException("Edge does not belong to this Terminal (must be outgoing only)");

			Edges = edges.ToList();
		}
	}
	public enum TerminalType
	{
		Hub, PickupPoint, DistributionCenter
	}
}
