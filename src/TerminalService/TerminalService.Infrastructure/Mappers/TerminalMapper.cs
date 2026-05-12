using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalService.Infrastructure.Mappers
{
	internal static class TerminalMapper
	{
		public static Facade.DataTransferObjects.Terminal Map(this Domain.Entities.Terminal terminal, int currentlyAllocated)
		{
			Facade.DataTransferObjects.City city = new Facade.DataTransferObjects.City(
				terminal.Location.Address.City.CityName,
				terminal.Location.Address.City.ZipCode);

			Facade.DataTransferObjects.Address address = new Facade.DataTransferObjects.Address(
				city,
				terminal.Location.Address.Street,
				terminal.Location.Address.StreetNumber);

			Facade.DataTransferObjects.Region region = new Facade.DataTransferObjects.Region(
				terminal.Location.Region.Country,
				terminal.Location.Region.MainRegion,
				terminal.Location.Region.SubRegion);

			Facade.DataTransferObjects.Location location = new Facade.DataTransferObjects.Location(
				region,
				address);

			return new Facade.DataTransferObjects.Terminal(
				terminal.Id,
				(Facade.DataTransferObjects.TerminalType)terminal.Type,
				terminal.DailyCapacity,
				location,
				currentlyAllocated);
		}
	}
}
