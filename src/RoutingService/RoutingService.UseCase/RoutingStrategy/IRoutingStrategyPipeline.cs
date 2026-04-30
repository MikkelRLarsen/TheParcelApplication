using RoutingService.Domain;
using RoutingService.UseCase.GraphEntities;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingStrategy
{
	public interface IRoutingStrategyPipeline
	{
		public Task<ResultT<Graph>> ExecuteAsync(Terminal from, Terminal to);
	}
}
