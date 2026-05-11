using Shared.ResultPattern;
using TerminalService.Api.DataTransferObjects;
using TerminalService.Facade;
using static TerminalService.Api.Middleware.ApiExceptions;

namespace TerminalService.Api.Controllers
{
	public sealed class TerminalControllerImplementation : ITerminalController
	{
		private readonly IAllocateRequestCommand _command;
		private readonly ICheckIfExistQuery _query;
		private readonly HttpContext _httpContext;

		public TerminalControllerImplementation(IAllocateRequestCommand command, IHttpContextAccessor httpContextAccessor, ICheckIfExistQuery query)
		{
			_command = command;
			_httpContext = httpContextAccessor.HttpContext!;
			_query = query;
		}

		public async Task CheckTerminalByIdAsync(Guid id)
		{
			Result result = await _query.Handle(id);

			if (result.Status == ResultStatus.Success) 
				return;

			switch (result.Error!.ErrorType)
			{
				case ErrorType.NotFound:
					throw new NotFoundException(result.Error.Description);

				default:
					throw new InternalException(result.Error.Description);
			}
		}


		public async Task ProcessAllocationRequestAsync(AllocationRequestEvent body)
		{
			Result result = await _command.TryHandle(body.Map());

			if (result.Status is ResultStatus.Success ||
				result.Status is ResultStatus.HandledError)
			{
				_httpContext.Response.StatusCode = StatusCodes.Status201Created;
				return;
			}

			switch (result.Error!.ErrorType)
			{
				case ErrorType.BadRequest:
					throw new BadRequest(result.Error.Description);

				case ErrorType.Conflict:
					throw new ConflictException(result.Error.Description);

				default:
					throw new InternalException(result.Error.Description);
			}
		}
	}
}
