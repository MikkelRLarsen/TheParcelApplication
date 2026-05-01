using RoutingService.Domain;
using RoutingService.UseCase.GraphEntities;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.RoutingAlgoritme;
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
		private readonly IRouteAlgoritme _routeAlgoritme;

		public MainAreaStrategy(ITerminalRepository repo, IRouteAlgoritme routeAlgoritme)
		{
			_repo = repo;
			_routeAlgoritme = routeAlgoritme;
		}

		public RoutingOrder Order => RoutingOrder.Second;

		public bool CanHandle(Terminal from, Terminal to)
		{
			return from.Region.MainRegion == to.Region.MainRegion;
		}

		public async Task<ResultT<IRoutePath>> TryExecute(Terminal from, Terminal to)
		{
			ISpecification<Terminal> spec =
				new MainAreaSpecification(
					mainRegionTarget: from.Region.MainRegion,
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
