using RoutingService.Domain;
using RoutingService.UseCase.GraphEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingStrategy
{
	public interface IRoutingStrategy
	{
		public Graph Execute(Terminal from, Terminal to);
	}
}
