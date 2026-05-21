using System.Diagnostics.CodeAnalysis;

namespace TerminalService.Api.DataTransferObjects
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

		public static Terminal Map(Facade.DataTransferObjects.Terminal terminal)
		{
			return new Terminal(
				id: terminal.Id,
				type: (TerminalType)terminal.Type,
				dailyCapacity: terminal.DailyCapacity,
				location: Location.Map(terminal.Location),
				currentlyReserved: terminal.CurrentlyReserved);
		}
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

		public static Location Map(Facade.DataTransferObjects.Location location)
		{
			return new Location(
				region: Region.Map(location.Region),
				address: Address.Map(location.Address));
		}
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

		public static Region Map(Facade.DataTransferObjects.Region region)
		{
			return new Region(
				country: region.Country,
				mainRegion: region.MainRegion,
				subRegion: region.SubRegion);
		}
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

		public static Address Map(Facade.DataTransferObjects.Address address)
		{
			return new Address(
				city: City.Map(address.City),
				street: address.Street,
				streetNumber: address.StreetNumber);
		}
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

		public static City Map(Facade.DataTransferObjects.City city)
		{
			return new City(
				cityName: city.CityName,
				zipCode: city.ZipCode);
		}
	}
}
