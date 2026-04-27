using RoutingService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Domain
{
	public sealed class Edge
	{
		public Guid From { get; private set; }
		public Guid To { get; private set; }
		public int weight { get; private set; }
	}
}
