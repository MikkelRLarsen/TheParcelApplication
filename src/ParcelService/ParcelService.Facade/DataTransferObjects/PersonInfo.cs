using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public record PersonInfo
	{
		public required string Name { get; init; }
		public required Address Address { get; init; }

		[SetsRequiredMembers]
		public PersonInfo(string name, Address address)
		{
			Name = name;
			Address = address;
		}
	}
}
