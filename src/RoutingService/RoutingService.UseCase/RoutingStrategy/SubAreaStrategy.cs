using RoutingService.Domain;
using RoutingService.UseCase.GraphEntities;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.SpecificationPattern;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.RoutingStrategy
{
	public sealed class SubAreaStrategy : IRoutingStrategy
	{
		private readonly ITerminalRepository _repo;

		public SubAreaStrategy(ITerminalRepository repo)
		{
			_repo = repo;
		}

		public RoutingOrder Order => RoutingOrder.First;

		public bool CanHandle(Terminal from, Terminal to)
		{
			return from.Region.SubRegion == to.Region.SubRegion;
		}

		public async Task<ResultT<Graph>> TryExecute(Terminal from, Terminal to)
		{
			ISpecification<Terminal> spec = 
				new SubAreaSpecification(
					fromId: from.Id, 
					toId: to.Id
				);
			
			var t = await _repo.GetAllAsync(spec);
			if (t.Status is ResultStatus.Success)
				return new Graph(t.Value.ToArray());

			return ResultT<Graph>.Failure(Error.BadRequest("PIPELINE.ERROR", "This Strategy doesnt fit"));
		}
	}
}
