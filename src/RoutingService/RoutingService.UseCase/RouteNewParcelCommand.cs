using RoutingService.Facade;
using RoutingService.Facade.DataTransferObjects;
using RoutingService.UseCase.RoutingStrategy;
using Shared.ResultPattern;
using RoutingService.UseCase.InfrastructureInterfaces;

namespace RoutingService.UseCase
{
	public sealed class RouteNewParcelCommand : IRouteNewParcelCommand
	{
		private readonly IRoutingStrategyPipeline _pipeline;
		private readonly ITerminalRepository _terminalRepository;
		private readonly ISagaStarter _sagaStarter;

		public RouteNewParcelCommand(IRoutingStrategyPipeline pipeline, ITerminalRepository terminalRepository, ISagaStarter sagaStarter)
		{
			_pipeline = pipeline;
			_terminalRepository = terminalRepository;
			_sagaStarter = sagaStarter;
		}

		public async Task<Result> Handle(RouteNewParcel command)
		{
			var senderResult = await _terminalRepository.LoadAsync(command.SenderTerminal);
			if (senderResult.Status is ResultStatus.Failure) return senderResult.Error!;

			var recieverResult = await _terminalRepository.LoadAsync(command.ReceiverTerminal);
			if (recieverResult.Status is ResultStatus.Failure) return recieverResult.Error!;

			var pipelineResult = await _pipeline.ExecuteAsync(
				from: senderResult.Value,
				to: recieverResult.Value);

			if (pipelineResult.Status is ResultStatus.Failure)
				return Result.Failure(pipelineResult.Error!);

			await _sagaStarter.StartAllocateSaga(
				trackingNumber: command.TrackingNumber,
				routePath: pipelineResult.Value,
				priority: command.Priority);

			return Result.Success();
		}
	}
}
