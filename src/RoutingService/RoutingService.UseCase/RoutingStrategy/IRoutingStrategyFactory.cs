using System;
using System.Collections.Generic;
using System.Text;
using RoutingService.Domain;

namespace RoutingService.UseCase.RoutingStrategy
{
	public interface IRoutingStrategyFactory
	{
		public IRoutingStrategy Create();
	}
}
