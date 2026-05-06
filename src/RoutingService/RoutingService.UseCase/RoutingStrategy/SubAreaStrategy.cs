using RoutingService.Domain;
using RoutingService.UseCase.GraphEntities;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.RoutingAlgoritme;
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
		private readonly IRouteAlgoritme _routeAlgoritme;

		public SubAreaStrategy(ITerminalRepository repo, IRouteAlgoritme routeAlgoritme)
		{
			_repo = repo;
			_routeAlgoritme = routeAlgoritme;
		}

		public RoutingOrder Order => RoutingOrder.First;

		public bool CanHandle(Terminal from, Terminal to)
		{
			return from.Region.SubRegion == to.Region.SubRegion;
		}

		public async Task<ResultT<IRoutePath>> TryExecute(Terminal from, Terminal to)
		{
			ISpecification<Terminal> spec = 
				new SubAreaSpecification(
					subRegionTarget: from.Region.SubRegion,
					fromId: from.Id, 
					toId: to.Id
				);

			var repoResult = await _repo.LoadAllAsync(spec);
			if (repoResult.Status is ResultStatus.Failure)
				return repoResult.Error!;


			return _routeAlgoritme.Calculate(new Graph(
				repoResult.Value.ToArray()),
				from.Id,
				to.Id);
		}
	}
}
