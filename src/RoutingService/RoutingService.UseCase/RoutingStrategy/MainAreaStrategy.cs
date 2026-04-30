using RoutingService.Domain;
using RoutingService.UseCase.GraphEntities;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.SpecificationPattern;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RoutingService.UseCase.RoutingStrategy
{
	public sealed class MainAreaStrategy : IRoutingStrategy
	{
		private readonly ITerminalRepository _repo;

		public MainAreaStrategy(ITerminalRepository repo)
		{
			_repo = repo;
		}

		public RoutingOrder Order => RoutingOrder.Second;

		public bool CanHandle(Terminal from, Terminal to)
		{
			return from.Region.MainRegion == to.Region.MainRegion;
		}

		public async Task<ResultT<Graph>> TryExecute(Terminal from, Terminal to)
		{
			ISpecification<Terminal> spec1 =
				new MainAreaSpecification(
					mainAreaTarget: from.Region.MainRegion,
					fromId: from.Id,
					toId: to.Id
				);

			var t1 = await _repo.GetAllAsync(spec1);
			if (t1.Status is ResultStatus.Success)
				return new Graph(t1.Value.ToArray());

			return ResultT<Graph>.Failure(Error.BadRequest("PIPELINE.ERROR", "This Strategy doesnt fit"));
		}
	}
}
