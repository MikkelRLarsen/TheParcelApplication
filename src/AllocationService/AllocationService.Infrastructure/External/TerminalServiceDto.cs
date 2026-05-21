using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.Infrastructure.External
{
	public sealed record TerminalServiceDto
	{
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

		public required Region Region { get; init; } = null!;
		public required Address Address { get; init; } = null!;
	}
	public sealed record Region
	{
		public required string Country { get; init; } = null!;
		public required string MainRegion { get; init; } = null!;
		public required string SubRegion { get; init; } = null!;
	}
	public sealed record Address
	{
		public required City City { get; init; } = null!;
		public required string Street { get; init; } = null!;
		public required int StreetNumber { get; init; }
	}
	public sealed record City
	{
		public required string CityName { get; init; } = null!;
		public required int ZipCode { get; init; }
	}
}
