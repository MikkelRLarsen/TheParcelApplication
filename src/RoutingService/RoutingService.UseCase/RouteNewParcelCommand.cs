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

		public RouteNewParcelCommand(IRoutingStrategyPipeline pipeline, ITerminalRepository terminalRepository)
		{
			_pipeline = pipeline;
			_terminalRepository = terminalRepository;
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

			//TODO Create SAGA Event

			return Result.Success();
		}
	}
}
