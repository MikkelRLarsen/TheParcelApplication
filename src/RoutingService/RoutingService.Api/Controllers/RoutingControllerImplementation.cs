using RoutingService.Api.DataTransferObjects;
using RoutingService.Facade;
using Shared.ResultPattern;
using static RoutingService.Api.Middleware.ApiExceptions;

namespace RoutingService.Api.Controllers
{
	public sealed class RoutingControllerImplementation : IRoutingController
	{
		private readonly IRouteNewParcelCommand _routeNewParcelCommand;
		private readonly HttpContext _httpContext;
		private readonly ISagaRaiseEvent _sagaRaiseEvent;

		public RoutingControllerImplementation(IRouteNewParcelCommand routeNewParcelCommand, IHttpContextAccessor contextAccessor, ISagaRaiseEvent sagaRaiseEvent)
		{
			_routeNewParcelCommand = routeNewParcelCommand;
			_httpContext = contextAccessor.HttpContext!;
			_sagaRaiseEvent = sagaRaiseEvent;
		}

		public async Task ProcessAllocationReceivedAsync(AllocationReceivedEvent body)
		{
			await _sagaRaiseEvent.RaiseSagaEvent(body.Map());
		}

		public async Task ProcessNewParcelAsync(NewParcelEvent body)
		{
			Result result = await _routeNewParcelCommand.Handle(body.Map());

			if (result.Status is ResultStatus.Success)
			{
				_httpContext.Response.StatusCode = StatusCodes.Status202Accepted;
				return;
			}

			switch (result.Error!.ErrorType)
			{
				case ErrorType.BadRequest:
					throw new BadRequest(result.Error.Description);

				default:
					throw new InternalException(result.Error.Description);
			}
		}
	}
}
