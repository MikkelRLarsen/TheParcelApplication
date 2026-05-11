using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TerminalService.Domain.ValueObjects
{
	public sealed record City
	{
		[SetsRequiredMembers]
		public City(string cityName, int zipCode)
		{
			CityName = cityName;
			ZipCode = zipCode;
		}

		[SetsRequiredMembers]
		private City() { }

		public required string CityName { get; init; } = null!;
		public required int ZipCode { get; init; }
	}
}
