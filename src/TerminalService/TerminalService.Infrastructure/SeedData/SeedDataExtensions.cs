using Microsoft.EntityFrameworkCore.Migrations;

namespace RoutingService.Infrastructure.SeedData
{
	internal static class SeedDataExtensions
	{
		public static void SeedTerminals(this MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Terminal",
				columns:
				[
					"Id",
					"Type",
					"DailyCapacity",

					// Region
					"Country",
					"MainRegion",
					"SubRegion",

					// Address
					"CityName",
					"ZipCode",
					"Street",
					"StreetNumber"
				],
				values: new object[,]
				{
					// =========================
					// HUBS (100)
					// =========================
					{ TerminalSeedIds.Hub_CPH, "Hub", 100, "Danmark", "Sjælland", "Hovedstaden", "København", "1000", "Hovedgade", "1" },
					{ TerminalSeedIds.Hub_Vejle, "Hub", 100, "Danmark", "Jylland", "Trekantsområdet", "Vejle", "7100", "Industrivej", "10" },

					// =========================
					// DC – JYLLAND (50)
					// =========================
					{ TerminalSeedIds.DC_Aarhus, "DistributionCenter", 50, "Danmark", "Jylland", "Aarhus", "Aarhus", "8000", "Logistikvej", "1" },
					{ TerminalSeedIds.DC_Aalborg, "DistributionCenter", 50, "Danmark", "Jylland", "Aalborg", "Aalborg", "9000", "Logistikvej", "2" },
					{ TerminalSeedIds.DC_Esbjerg, "DistributionCenter", 50, "Danmark", "Jylland", "Esbjerg", "Esbjerg", "6700", "Logistikvej", "3" },
					{ TerminalSeedIds.DC_Herning, "DistributionCenter", 50, "Danmark", "Jylland", "Herning", "Herning", "7400", "Logistikvej", "4" },
					{ TerminalSeedIds.DC_Horsens, "DistributionCenter", 50, "Danmark", "Jylland", "Horsens", "Horsens", "8700", "Logistikvej", "5" },
					{ TerminalSeedIds.DC_Viborg, "DistributionCenter", 50, "Danmark", "Jylland", "Viborg", "Viborg", "8800", "Logistikvej", "6" },
					{ TerminalSeedIds.DC_Randers, "DistributionCenter", 50, "Danmark", "Jylland", "Randers", "Randers", "8900", "Logistikvej", "7" },
					{ TerminalSeedIds.DC_Hjoerring, "DistributionCenter", 50, "Danmark", "Jylland", "Hjørring", "Hjørring", "9800", "Logistikvej", "8" },

					// =========================
					// DC – SJÆLLAND (50)
					// =========================
					{ TerminalSeedIds.DC_Roskilde, "DistributionCenter", 50, "Danmark", "Sjælland", "Roskilde", "Roskilde", "4000", "Logistikvej", "9" },
					{ TerminalSeedIds.DC_Koege, "DistributionCenter", 50, "Danmark", "Sjælland", "Køge", "Køge", "4600", "Logistikvej", "10" },
					{ TerminalSeedIds.DC_Hillerod, "DistributionCenter", 50, "Danmark", "Sjælland", "Hillerød", "Hillerød", "3400", "Logistikvej", "11" },
					{ TerminalSeedIds.DC_Slagelse, "DistributionCenter", 50, "Danmark", "Sjælland", "Slagelse", "Slagelse", "4200", "Logistikvej", "12" },
					{ TerminalSeedIds.DC_Naestved, "DistributionCenter", 50, "Danmark", "Sjælland", "Næstved", "Næstved", "4700", "Logistikvej", "13" },

					// =========================
					// DC – FYN (50)
					// =========================
					{ TerminalSeedIds.DC_Odense, "DistributionCenter", 50, "Danmark", "Fyn", "Odense", "Odense", "5000", "Logistikvej", "14" },
					{ TerminalSeedIds.DC_Svendborg, "DistributionCenter", 50, "Danmark", "Fyn", "Svendborg", "Svendborg", "5700", "Logistikvej", "15" },

					// =========================
					// DC – BORNHOLM (50)
					// =========================
					{ TerminalSeedIds.DC_Roenne, "DistributionCenter", 50, "Danmark", "Bornholm", "Rønne", "Rønne", "3700", "Logistikvej", "16" },

					// =========================
					// PP – SJÆLLAND (20)
					// =========================
					{ TerminalSeedIds.PP_Koebenhavn, "PickupPoint", 20, "Danmark", "Sjælland", "København", "København", "1000", "Butiksgade", "1" },
					{ TerminalSeedIds.PP_Frederiksberg, "PickupPoint", 20, "Danmark", "Sjælland", "Frederiksberg", "Frederiksberg", "2000", "Butiksgade", "2" },
					{ TerminalSeedIds.PP_Glentofte, "PickupPoint", 20, "Danmark", "Sjælland", "Gentofte", "Gentofte", "2820", "Butiksgade", "3" },
					{ TerminalSeedIds.PP_Helsingoer, "PickupPoint", 20, "Danmark", "Sjælland", "Helsingør", "Helsingør", "3000", "Butiksgade", "4" },
					{ TerminalSeedIds.PP_Helsingor, "PickupPoint", 20, "Danmark", "Sjælland", "Helsingør", "Helsingør", "3000", "Butiksgade", "5" },
					{ TerminalSeedIds.PP_Slagelse, "PickupPoint", 20, "Danmark", "Sjælland", "Slagelse", "Slagelse", "4200", "Butiksgade", "6" },
					{ TerminalSeedIds.PP_Naestved, "PickupPoint", 20, "Danmark", "Sjælland", "Næstved", "Næstved", "4700", "Butiksgade", "7" },
					{ TerminalSeedIds.PP_Ringsted, "PickupPoint", 20, "Danmark", "Sjælland", "Ringsted", "Ringsted", "4100", "Butiksgade", "8" },

					// =========================
					// PP – JYLLAND (20)
					// =========================
					{ TerminalSeedIds.PP_Aarhus, "PickupPoint", 20, "Danmark", "Jylland", "Aarhus", "Aarhus", "8000", "Butiksgade", "9" },
					{ TerminalSeedIds.PP_Randers, "PickupPoint", 20, "Danmark", "Jylland", "Randers", "Randers", "8900", "Butiksgade", "10" },
					{ TerminalSeedIds.PP_Viborg, "PickupPoint", 20, "Danmark", "Jylland", "Viborg", "Viborg", "8800", "Butiksgade", "11" },
					{ TerminalSeedIds.PP_Silkeborg, "PickupPoint", 20, "Danmark", "Jylland", "Silkeborg", "Silkeborg", "8600", "Butiksgade", "12" },
					{ TerminalSeedIds.PP_Horsens, "PickupPoint", 20, "Danmark", "Jylland", "Horsens", "Horsens", "8700", "Butiksgade", "13" },
					{ TerminalSeedIds.PP_Esbjerg, "PickupPoint", 20, "Danmark", "Jylland", "Esbjerg", "Esbjerg", "6700", "Butiksgade", "14" },
					{ TerminalSeedIds.PP_Herning, "PickupPoint", 20, "Danmark", "Jylland", "Herning", "Herning", "7400", "Butiksgade", "15" },
					{ TerminalSeedIds.PP_Holstebro, "PickupPoint", 20, "Danmark", "Jylland", "Holstebro", "Holstebro", "7500", "Butiksgade", "16" },
					{ TerminalSeedIds.PP_Aalborg, "PickupPoint", 20, "Danmark", "Jylland", "Aalborg", "Aalborg", "9000", "Butiksgade", "17" },
					{ TerminalSeedIds.PP_Hjoerring, "PickupPoint", 20, "Danmark", "Jylland", "Hjørring", "Hjørring", "9800", "Butiksgade", "18" },
					{ TerminalSeedIds.PP_Frederikshavn, "PickupPoint", 20, "Danmark", "Jylland", "Frederikshavn", "Frederikshavn", "9900", "Butiksgade", "19" },

					// =========================
					// PP – FYN & BORNHOLM (20)
					// =========================
					{ TerminalSeedIds.PP_Odense, "PickupPoint", 20, "Danmark", "Fyn", "Odense", "Odense", "5000", "Butiksgade", "20" },
					{ TerminalSeedIds.PP_Svendborg, "PickupPoint", 20, "Danmark", "Fyn", "Svendborg", "Svendborg", "5700", "Butiksgade", "21" },
					{ TerminalSeedIds.PP_Nyborg, "PickupPoint", 20, "Danmark", "Fyn", "Nyborg", "Nyborg", "5800", "Butiksgade", "22" },
					{ TerminalSeedIds.PP_Middelfart, "PickupPoint", 20, "Danmark", "Fyn", "Middelfart", "Middelfart", "5500", "Butiksgade", "23" },
					{ TerminalSeedIds.PP_Roenne, "PickupPoint", 20, "Danmark", "Bornholm", "Rønne", "Rønne", "3700", "Butiksgade", "24" }
				}
			);
		}
	}
}
