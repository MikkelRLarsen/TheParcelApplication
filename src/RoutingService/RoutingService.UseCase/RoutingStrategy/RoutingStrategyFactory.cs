using RoutingService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingStrategy
{
	public sealed class RoutingStrategyFactory : IRoutingStrategyFactory
	{
		public IRoutingStrategy Create(Terminal from, Terminal to)
		{
			throw new NotImplementedException();
		}
	}
}
