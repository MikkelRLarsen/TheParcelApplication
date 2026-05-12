using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.Infrastructure.InfrastructureErros
{
	public static class HttpError
	{
		public static Error JSONFormattingError(Guid id) =>
			Error.Failure("Http.Error", $"Unexpected error when retrieving Terminal with Id:{id}");

		public static Error NotFound(Guid id) =>
			Error.NotFound("Http.Error", $"HttpRequest returned 404 NotFound on Terminal with Id:{id}");

		public static Error RequestFailed(Guid id) =>
			Error.Failure("Http.Error", $"HttpRequest returned non-successful statuscode");
	}
}
