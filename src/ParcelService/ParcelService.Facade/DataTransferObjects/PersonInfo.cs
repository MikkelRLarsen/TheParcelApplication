using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ParcelService.Facade.DataTransferObjects
{
	public record PersonInfo
	{
		public string Name { get; init; }
		public Address Address { get; init; }

		public PersonInfo(string name, Address address)
		{
			Name = name;
			Address = address;
		}
	}
}
