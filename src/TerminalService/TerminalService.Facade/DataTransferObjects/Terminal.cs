using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TerminalService.Facade.DataTransferObjects
{
	public sealed record Terminal
	{
		[SetsRequiredMembers]
		public Terminal(Guid id, TerminalType type, int dailyCapacity, Location location, int currentlyReserved)
		{
			Id = id;
			Type = type;
			DailyCapacity = dailyCapacity;
			Location = location;
			CurrentlyReserved = currentlyReserved;
		}

		public required Guid Id { get; init; }
		public required TerminalType Type { get; init; }
		public required int DailyCapacity { get; init; }
		public required int CurrentlyReserved { get; init; }
		public required Location Location { get; init; } = null!;
	}
	public enum TerminalType
	{
		Hub, PickupPoint, DistributionCenter
	}
	public sealed record Location
	{
		[SetsRequiredMembers]
		public Location(Region region, Address address)
		{
			Region = region;
			Address = address;
		}

		public required Region Region { get; init; } = null!;
		public required Address Address { get; init; } = null!;
	}
	public sealed record Region
	{
		[SetsRequiredMembers]
		public Region(string country, string mainRegion, string subRegion)
		{
			Country = country;
			MainRegion = mainRegion;
			SubRegion = subRegion;
		}

		public required string Country { get; init; } = null!;
		public required string MainRegion { get; init; } = null!;
		public required string SubRegion { get; init; } = null!;
	}
	public sealed record Address
	{
		[SetsRequiredMembers]
		public Address(City city, string street, int streetNumber)
		{
			City = city;
			Street = street;
			StreetNumber = streetNumber;
		}

		public required City City { get; init; } = null!;
		public required string Street { get; init; } = null!;
		public required int StreetNumber { get; init; }
	}
	public sealed record City
	{
		[SetsRequiredMembers]
		public City(string cityName, int zipCode)
		{
			CityName = cityName;
			ZipCode = zipCode;
		}

		public required string CityName { get; init; } = null!;
		public required int ZipCode { get; init; }
	}
}
