using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TerminalService.Domain.ValueObjects
{
	public sealed record Date
	{
		public required DateTime DateTime { get; init; }
		public DateOnly GetDateOnly => DateOnly.FromDateTime(DateTime);

		[SetsRequiredMembers]
		public Date()
		{
			DateTime = DateTime.UtcNow;
		}

		[SetsRequiredMembers]
		public Date(DateTime dateTime)
		{
			DateTime = dateTime.Kind switch 
			{ 
				DateTimeKind.Utc => dateTime, 
				DateTimeKind.Local => dateTime.ToUniversalTime(), 
				_ => DateTime.SpecifyKind(dateTime, DateTimeKind.Utc) 
			};
		}

		public static implicit operator Date(DateOnly date)
			=> new(DateTime.SpecifyKind(
				date.ToDateTime(TimeOnly.MinValue),
				DateTimeKind.Utc));
	}
}
