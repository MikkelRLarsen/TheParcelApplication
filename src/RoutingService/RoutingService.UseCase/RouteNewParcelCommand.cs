using RoutingService.Facade;
using RoutingService.Facade.DataTransferObjects;
using RoutingService.UseCase.GraphEntities;
using RoutingService.UseCase.Mappers;
using RoutingService.UseCase.RoutingStrategy;
using Shared.ResultPattern;
using RoutingService.UseCase.RoutingAlgoritme;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase
{
	public sealed class RouteNewParcelCommand : IRouteNewParcelCommand
	{
		private readonly IRoutingStrategyPipeline _pipeline;

		public RouteNewParcelCommand(IRoutingStrategyPipeline pipeline)
		{
			_pipeline = pipeline;
		}

		public async Task<Result> Handle(RouteNewParcel command)
		{
			ResultT<Domain.Terminal> senderResult = command.SenderTerminal.MapToDomainTerminal();
			ResultT<Domain.Terminal> recieverResult = command.ReceiverTerminal.MapToDomainTerminal();

			if (recieverResult.Status is ResultStatus.Failure ||
				senderResult.Status is ResultStatus.Failure)
				return Result.Failure(MappingError.MappingFailure("Couldn't map from Facade.Terminal to Domain.Terminal"));

			var pipelineResult = await _pipeline.ExecuteAsync(
				from: senderResult.Value,
				to: recieverResult.Value);

			if (pipelineResult.Status is ResultStatus.Failure)
				return Result.Failure(pipelineResult.Error!);

			Graph graph = pipelineResult.Value;
			var djikstraResult = graph.CalculateDijstra(
				startId: senderResult.Value.Id, 
				needleId: recieverResult.Value.Id);

			return Result.Success();
		}
	}
}
