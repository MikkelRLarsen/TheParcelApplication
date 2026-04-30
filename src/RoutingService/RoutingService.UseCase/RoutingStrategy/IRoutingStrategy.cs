using RoutingService.Domain;
using RoutingService.UseCase.GraphEntities;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingStrategy
{
	public interface IRoutingStrategy
	{
		public RoutingOrder Order { get; }
		public bool CanHandle(Terminal from, Terminal to);
		public Task<ResultT<Graph>> TryExecute(Terminal from, Terminal to);
	}

	public enum RoutingOrder
	{
		First = 100, Second = 90, Third = 80
	}
}
