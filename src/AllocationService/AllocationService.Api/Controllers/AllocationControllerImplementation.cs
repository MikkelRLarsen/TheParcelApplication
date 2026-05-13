using AllocationService.Api.DataTransferObjects;
using AllocationService.Facade;
using Shared.ResultPattern;
using static AllocationService.Api.Middleware.ApiExceptions;

namespace AllocationService.Api.Controllers
{
	public sealed class AllocationControllerImplementation : IAllocationController
	{
		private readonly IAllocateRequestCommand _command;
		private readonly HttpContext _httpContext;
		private readonly IAllocationRequestFailedCommand _commandFailed;
		private readonly IUpdateTerminalCapacityCommand _commandCapacity;

		public AllocationControllerImplementation(IAllocateRequestCommand command, IHttpContextAccessor httpContextAccessor, IAllocationRequestFailedCommand commandFailed, IUpdateTerminalCapacityCommand commandCapacity)
		{
			_command = command;
			_httpContext = httpContextAccessor.HttpContext!;
			_commandFailed = commandFailed;
			_commandCapacity = commandCapacity;
		}

		public async Task ProcessAllocationRequestAsync(AllocateRequestV1 body)
		{
			Result result = await _command.HandleAsync(body.Map());

			if (result.Status is ResultStatus.Success)
			{
				_httpContext.Response.StatusCode = StatusCodes.Status201Created;
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

		public async Task ProcessFailedAllocationRequestAsync(AllocationRequestFailed body)
		{
			Result result = await _commandFailed.HandleAsync(body.Map());

			if (result.Status is ResultStatus.Success)
			{
				_httpContext.Response.StatusCode = StatusCodes.Status201Created;
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

		public async Task UpdateCacheCapacityAsync(UpdateTerminalCapacity body)
		{
			Result result = await _commandCapacity.HandleAsync(body.Map());

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
