using RoutingService.Domain;
using Shared.ResultPattern;

namespace RoutingService.Infrastructure.DatabaseErrors
{
    public static class DatabaseError
    {
        public static Error DatabaseGetError(Terminal terminal) =>
            Error.Failure("Database.Error", $"Unexpected error when retrieving Terminal with Id:{terminal.Id}");

        public static Error DatabaseSaveChangesError() =>
            Error.Failure("Database.Error", "Unexpected error when saving changes to databasen");

        public static Error DatabaseGetError(Edge edge) =>
			Error.Failure("Database.Error", $"Unexpected error when retrieving Edge with Id:{edge.Id}");
	}
}
