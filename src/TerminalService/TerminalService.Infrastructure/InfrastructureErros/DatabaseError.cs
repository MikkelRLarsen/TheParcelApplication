using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.Domain.Entities;

namespace TerminalService.Infrastructure.InfrastructureErros
{
	public static class DatabaseError
	{
		public static Error DatabaseGetError(Guid id) =>
			Error.Failure("Database.Error", $"Unexpected error when retrieving Terminal with Id:{id}");

		public static Error DatabaseGetError() =>
			Error.Failure("Database.Error", $"Unexpected error when retrieving all Terminals");

		public static Error NotFound(Guid id) =>
			Error.NotFound("Database.Error", $"No terminal found with Id:{id}");

		public static Error Concurrency() =>
			Error.Conflict("Database.Error", $"A concurrency happend when allocating parcel to Terminal");

		public static Error AllocateError(TerminalAllocation allocation) =>
			Error.Failure("Database.Error", $"Unexpected error when allocation parcel with TrackingNumber:{allocation.TrackingNumber} on Terminal with Id{allocation.TerminalId}");
	}
}
