using Shared.ResultPattern;

namespace AllocationService.Infrastructure.InfrastructureErros
{
	public static class CacheError
	{
		public static Error GetError(Guid id) =>
			Error.Failure("Cache.Error", $"Unexpected error when retrieving Terminal with Id:{id}");

		public static Error NotFound(Guid id) =>
			Error.NotFound("Cache.Error", $"No terminal found with Id:{id}");

		public static Error CreatingError(Guid id) =>
			Error.Failure("Cache.Error", $"Unexpected error when creating cache for Terminal with Id:{id}");

		public static Error UpdateError(Guid id) =>
			Error.Failure("Cache.Error", $"Unexpected error when updating cache for Terminal with Id:{id}");
	}
}
