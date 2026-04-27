using RoutingService.Api.DataTransferObjects;
using RoutingService.Facade;
using Shared.ResultPattern;
using static RoutingService.Api.Middleware.ApiExceptions;

namespace RoutingService.Api.Controllers
{
	public sealed class RoutingControllerImplementation : IRoutingController
	{
		private readonly IRouteNewParcelCommand _command;
		private readonly ILogger<RoutingControllerImplementation> _logger;
		private readonly HttpContext _httpContext;

		public RoutingControllerImplementation(IRouteNewParcelCommand command, ILogger<RoutingControllerImplementation> logger, IHttpContextAccessor contextAccessor)
		{
			_command = command;
			_logger = logger;
			_httpContext = contextAccessor.HttpContext!;
		}

		public async Task ProcessRoutingAsync(NewParcelEvent body)
		{
			Result result = await _command.Handle(body.Map());

			if(result.Status is ResultStatus.Success)
			{
				_httpContext.Response.StatusCode = StatusCodes.Status202Accepted;
				return;
			}

			switch (result.Error!.ErrorType)
			{
				case ErrorType.BadRequest:
					_logger.LogError($"A request returned 400 => {result.Error.Code}");
					throw new BadRequest(result.Error.Description);

				default:
					_logger.LogError($"A request returned 500 => {result.Error.Code}");
					throw new InternalException(result.Error.Description);
			}
		}
	}
}
