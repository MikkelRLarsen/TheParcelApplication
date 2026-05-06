using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using RoutingService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Infrastructure.SeedData
{
	internal static class SeedDataExtensions
	{
		public static void SeedEdges(this MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Edge",
				columns: new[] { "Id", "From", "To", "Weight" },
				values: new object[,]
				{

					{ EdgeSeedIds.E002, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.Hub_CPH, 90 },
					{ EdgeSeedIds.E001, TerminalSeedIds.Hub_CPH, TerminalSeedIds.Hub_Vejle, 90 },

					{ EdgeSeedIds.E003, TerminalSeedIds.Hub_CPH, TerminalSeedIds.DC_Koege, 30 },
					{ EdgeSeedIds.E004, TerminalSeedIds.DC_Koege, TerminalSeedIds.Hub_CPH, 30 },
					{ EdgeSeedIds.E005, TerminalSeedIds.Hub_CPH, TerminalSeedIds.DC_Hillerod, 35 },
					{ EdgeSeedIds.E006, TerminalSeedIds.DC_Hillerod, TerminalSeedIds.Hub_CPH, 35 },
					{ EdgeSeedIds.E007, TerminalSeedIds.Hub_CPH, TerminalSeedIds.DC_Slagelse, 40 },
					{ EdgeSeedIds.E008, TerminalSeedIds.DC_Slagelse, TerminalSeedIds.Hub_CPH, 40 },
					{ EdgeSeedIds.E009, TerminalSeedIds.Hub_CPH, TerminalSeedIds.DC_Naestved, 45 },
					{ EdgeSeedIds.E010, TerminalSeedIds.DC_Naestved, TerminalSeedIds.Hub_CPH, 45 },

					{ EdgeSeedIds.E011, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.DC_Aarhus, 20 },
					{ EdgeSeedIds.E012, TerminalSeedIds.DC_Aarhus, TerminalSeedIds.Hub_Vejle, 20 },
					{ EdgeSeedIds.E013, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.DC_Aalborg, 55 },
					{ EdgeSeedIds.E014, TerminalSeedIds.DC_Aalborg, TerminalSeedIds.Hub_Vejle, 55 },
					{ EdgeSeedIds.E015, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.DC_Esbjerg, 30 },
					{ EdgeSeedIds.E016, TerminalSeedIds.DC_Esbjerg, TerminalSeedIds.Hub_Vejle, 30 },
					{ EdgeSeedIds.E017, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.DC_Herning, 25 },
					{ EdgeSeedIds.E018, TerminalSeedIds.DC_Herning, TerminalSeedIds.Hub_Vejle, 25 },
					{ EdgeSeedIds.E019, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.DC_Horsens, 15 },
					{ EdgeSeedIds.E020, TerminalSeedIds.DC_Horsens, TerminalSeedIds.Hub_Vejle, 15 },
					{ EdgeSeedIds.E021, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.DC_Viborg, 28 },
					{ EdgeSeedIds.E022, TerminalSeedIds.DC_Viborg, TerminalSeedIds.Hub_Vejle, 28 },
					{ EdgeSeedIds.E023, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.DC_Randers, 22 },
					{ EdgeSeedIds.E024, TerminalSeedIds.DC_Randers, TerminalSeedIds.Hub_Vejle, 22 },
					{ EdgeSeedIds.E025, TerminalSeedIds.Hub_Vejle, TerminalSeedIds.DC_Hjoerring, 60 },
					{ EdgeSeedIds.E026, TerminalSeedIds.DC_Hjoerring, TerminalSeedIds.Hub_Vejle, 60 },

					{ EdgeSeedIds.E027, TerminalSeedIds.DC_Aarhus, TerminalSeedIds.DC_Randers, 15 },
					{ EdgeSeedIds.E028, TerminalSeedIds.DC_Randers, TerminalSeedIds.DC_Aarhus, 15 },
					{ EdgeSeedIds.E029, TerminalSeedIds.DC_Aarhus, TerminalSeedIds.DC_Horsens, 12 },
					{ EdgeSeedIds.E030, TerminalSeedIds.DC_Horsens, TerminalSeedIds.DC_Aarhus, 12 },
					{ EdgeSeedIds.E031, TerminalSeedIds.DC_Randers, TerminalSeedIds.DC_Aalborg, 25 },
					{ EdgeSeedIds.E032, TerminalSeedIds.DC_Aalborg, TerminalSeedIds.DC_Randers, 25 },
					{ EdgeSeedIds.E033, TerminalSeedIds.DC_Esbjerg, TerminalSeedIds.DC_Herning, 30 },
					{ EdgeSeedIds.E034, TerminalSeedIds.DC_Herning, TerminalSeedIds.DC_Esbjerg, 30 },
					{ EdgeSeedIds.E035, TerminalSeedIds.DC_Viborg, TerminalSeedIds.DC_Herning, 20 },
					{ EdgeSeedIds.E036, TerminalSeedIds.DC_Herning, TerminalSeedIds.DC_Viborg, 20 },
					{ EdgeSeedIds.E037, TerminalSeedIds.DC_Roskilde, TerminalSeedIds.DC_Koege, 10 },
					{ EdgeSeedIds.E038, TerminalSeedIds.DC_Koege, TerminalSeedIds.DC_Roskilde, 10 },
					{ EdgeSeedIds.E039, TerminalSeedIds.DC_Koege, TerminalSeedIds.DC_Slagelse, 25 },
					{ EdgeSeedIds.E040, TerminalSeedIds.DC_Slagelse, TerminalSeedIds.DC_Koege, 25 },

					{ EdgeSeedIds.E041, TerminalSeedIds.DC_Aarhus, TerminalSeedIds.PP_Aarhus, 5 },
					{ EdgeSeedIds.E042, TerminalSeedIds.PP_Aarhus, TerminalSeedIds.DC_Aarhus, 5 },
					{ EdgeSeedIds.E043, TerminalSeedIds.DC_Aarhus, TerminalSeedIds.PP_Silkeborg, 10 },
					{ EdgeSeedIds.E044, TerminalSeedIds.PP_Silkeborg, TerminalSeedIds.DC_Aarhus, 10 },
					{ EdgeSeedIds.E045, TerminalSeedIds.DC_Randers, TerminalSeedIds.PP_Randers, 5 },
					{ EdgeSeedIds.E046, TerminalSeedIds.PP_Randers, TerminalSeedIds.DC_Randers, 5 },
					{ EdgeSeedIds.E047, TerminalSeedIds.DC_Roskilde, TerminalSeedIds.PP_Koebenhavn, 15 },
					{ EdgeSeedIds.E048, TerminalSeedIds.PP_Koebenhavn, TerminalSeedIds.DC_Roskilde, 15 },
					{ EdgeSeedIds.E049, TerminalSeedIds.DC_Roskilde, TerminalSeedIds.PP_Frederiksberg, 18 },
					{ EdgeSeedIds.E050, TerminalSeedIds.PP_Frederiksberg, TerminalSeedIds.DC_Roskilde, 18 },

					{ EdgeSeedIds.E051, TerminalSeedIds.DC_Roskilde, TerminalSeedIds.PP_Glentofte, 20 },
					{ EdgeSeedIds.E052, TerminalSeedIds.PP_Glentofte, TerminalSeedIds.DC_Roskilde, 20 },
					{ EdgeSeedIds.E053, TerminalSeedIds.DC_Roskilde, TerminalSeedIds.PP_Helsingoer, 30 },
					{ EdgeSeedIds.E054, TerminalSeedIds.PP_Helsingoer, TerminalSeedIds.DC_Roskilde, 30 },
					{ EdgeSeedIds.E055, TerminalSeedIds.DC_Slagelse, TerminalSeedIds.PP_Slagelse, 5 },
					{ EdgeSeedIds.E056, TerminalSeedIds.PP_Slagelse, TerminalSeedIds.DC_Slagelse, 5 },
					{ EdgeSeedIds.E057, TerminalSeedIds.DC_Naestved, TerminalSeedIds.PP_Naestved, 5 },
					{ EdgeSeedIds.E058, TerminalSeedIds.PP_Naestved, TerminalSeedIds.DC_Naestved, 5 },
					{ EdgeSeedIds.E059, TerminalSeedIds.DC_Koege, TerminalSeedIds.PP_Ringsted, 18 },
					{ EdgeSeedIds.E060, TerminalSeedIds.PP_Ringsted, TerminalSeedIds.DC_Koege, 18 },

					{ EdgeSeedIds.E061, TerminalSeedIds.DC_Horsens, TerminalSeedIds.PP_Horsens, 5 },
					{ EdgeSeedIds.E062, TerminalSeedIds.PP_Horsens, TerminalSeedIds.DC_Horsens, 5 },
					{ EdgeSeedIds.E063, TerminalSeedIds.DC_Esbjerg, TerminalSeedIds.PP_Esbjerg, 5 },
					{ EdgeSeedIds.E064, TerminalSeedIds.PP_Esbjerg, TerminalSeedIds.DC_Esbjerg, 5 },
					{ EdgeSeedIds.E065, TerminalSeedIds.DC_Herning, TerminalSeedIds.PP_Herning, 5 },
					{ EdgeSeedIds.E066, TerminalSeedIds.PP_Herning, TerminalSeedIds.DC_Herning, 5 },
					{ EdgeSeedIds.E067, TerminalSeedIds.DC_Herning, TerminalSeedIds.PP_Holstebro, 15 },
					{ EdgeSeedIds.E068, TerminalSeedIds.PP_Holstebro, TerminalSeedIds.DC_Herning, 15 },
					{ EdgeSeedIds.E069, TerminalSeedIds.DC_Viborg, TerminalSeedIds.PP_Viborg, 5 },
					{ EdgeSeedIds.E070, TerminalSeedIds.PP_Viborg, TerminalSeedIds.DC_Viborg, 5 },
					{ EdgeSeedIds.E071, TerminalSeedIds.DC_Aalborg, TerminalSeedIds.PP_Aalborg, 5 },
					{ EdgeSeedIds.E072, TerminalSeedIds.PP_Aalborg, TerminalSeedIds.DC_Aalborg, 5 },
					{ EdgeSeedIds.E073, TerminalSeedIds.DC_Aalborg, TerminalSeedIds.PP_Hjoerring, 20 },
					{ EdgeSeedIds.E074, TerminalSeedIds.PP_Hjoerring, TerminalSeedIds.DC_Aalborg, 20 },
					{ EdgeSeedIds.E075, TerminalSeedIds.DC_Aalborg, TerminalSeedIds.PP_Frederikshavn, 30 },
					{ EdgeSeedIds.E076, TerminalSeedIds.PP_Frederikshavn, TerminalSeedIds.DC_Aalborg, 30 },

					{ EdgeSeedIds.E077, TerminalSeedIds.DC_Odense, TerminalSeedIds.PP_Odense, 5 },
					{ EdgeSeedIds.E078, TerminalSeedIds.PP_Odense, TerminalSeedIds.DC_Odense, 5 },
					{ EdgeSeedIds.E079, TerminalSeedIds.DC_Odense, TerminalSeedIds.PP_Nyborg, 15 },
					{ EdgeSeedIds.E080, TerminalSeedIds.PP_Nyborg, TerminalSeedIds.DC_Odense, 15 },
					{ EdgeSeedIds.E081, TerminalSeedIds.DC_Odense, TerminalSeedIds.PP_Middelfart, 18 },
					{ EdgeSeedIds.E082, TerminalSeedIds.PP_Middelfart, TerminalSeedIds.DC_Odense, 18 },
					{ EdgeSeedIds.E083, TerminalSeedIds.DC_Svendborg, TerminalSeedIds.PP_Svendborg, 5 },
					{ EdgeSeedIds.E084, TerminalSeedIds.PP_Svendborg, TerminalSeedIds.DC_Svendborg, 5 },

					{ EdgeSeedIds.E085, TerminalSeedIds.DC_Roenne, TerminalSeedIds.PP_Roenne, 5 },
					{ EdgeSeedIds.E086, TerminalSeedIds.PP_Roenne, TerminalSeedIds.DC_Roenne, 5 },

					{ EdgeSeedIds.E087, TerminalSeedIds.DC_Aarhus, TerminalSeedIds.PP_Horsens, 20 },
					{ EdgeSeedIds.E088, TerminalSeedIds.PP_Horsens, TerminalSeedIds.DC_Aarhus, 20 },
					{ EdgeSeedIds.E090, TerminalSeedIds.PP_Frederiksberg, TerminalSeedIds.DC_Roskilde, 22 },
					{ EdgeSeedIds.E091, TerminalSeedIds.DC_Koege, TerminalSeedIds.PP_Koebenhavn, 25 },
					{ EdgeSeedIds.E092, TerminalSeedIds.PP_Koebenhavn, TerminalSeedIds.DC_Koege, 25 },
					{ EdgeSeedIds.E093, TerminalSeedIds.DC_Horsens, TerminalSeedIds.PP_Aarhus, 25 },
					{ EdgeSeedIds.E095, TerminalSeedIds.DC_Esbjerg, TerminalSeedIds.PP_Holstebro, 35 },
					{ EdgeSeedIds.E096, TerminalSeedIds.PP_Holstebro, TerminalSeedIds.DC_Esbjerg, 35 },

					{ EdgeSeedIds.E097, TerminalSeedIds.DC_Viborg, TerminalSeedIds.PP_Silkeborg, 18 },
					{ EdgeSeedIds.E098, TerminalSeedIds.PP_Silkeborg, TerminalSeedIds.DC_Viborg, 18 },
					{ EdgeSeedIds.E099, TerminalSeedIds.DC_Aalborg, TerminalSeedIds.PP_Viborg, 40 },
					{ EdgeSeedIds.E100, TerminalSeedIds.PP_Viborg, TerminalSeedIds.DC_Aalborg, 40 },
					{ EdgeSeedIds.E101, TerminalSeedIds.DC_Randers, TerminalSeedIds.PP_Herning, 35 },
					{ EdgeSeedIds.E102, TerminalSeedIds.PP_Herning, TerminalSeedIds.DC_Randers, 35 },
					{ EdgeSeedIds.E103, TerminalSeedIds.DC_Slagelse, TerminalSeedIds.PP_Naestved, 20 },
					{ EdgeSeedIds.E104, TerminalSeedIds.PP_Naestved, TerminalSeedIds.DC_Slagelse, 20 },
					{ EdgeSeedIds.E105, TerminalSeedIds.PP_Aarhus, TerminalSeedIds.DC_Horsens, 5 },
					{ EdgeSeedIds.E106, TerminalSeedIds.DC_Horsens, TerminalSeedIds.Hub_Vejle, 20 },
					{ EdgeSeedIds.E107, TerminalSeedIds.Hub_CPH, TerminalSeedIds.DC_Roskilde, 40 },
				}
			);
		}
		

		public static void SeedTerminals(this MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Terminal",
				columns: new[] { "Id", "Type", "Country", "MainRegion", "SubRegion" },
				values: new object[,]
				{
                    // =========================
                    // HUBS
                    // =========================
                    { TerminalSeedIds.Hub_CPH, "Hub", "Danmark", "Sjælland", "Hovedstaden" },
					{ TerminalSeedIds.Hub_Vejle, "Hub", "Danmark", "Jylland", "Trekantsområdet" },

                    // =========================
                    // DISTRIBUTION CENTERS – JYLLAND
                    // =========================
                    { TerminalSeedIds.DC_Aarhus, "DistributionCenter", "Danmark", "Jylland", "Aarhus" },
					{ TerminalSeedIds.DC_Aalborg, "DistributionCenter", "Danmark", "Jylland", "Aalborg" },
					{ TerminalSeedIds.DC_Esbjerg, "DistributionCenter", "Danmark", "Jylland", "Esbjerg" },
					{ TerminalSeedIds.DC_Herning, "DistributionCenter", "Danmark", "Jylland", "Herning" },
					{ TerminalSeedIds.DC_Horsens, "DistributionCenter", "Danmark", "Jylland", "Horsens" },
					{ TerminalSeedIds.DC_Viborg, "DistributionCenter", "Danmark", "Jylland", "Viborg" },
					{ TerminalSeedIds.DC_Randers, "DistributionCenter", "Danmark", "Jylland", "Randers" },
					{ TerminalSeedIds.DC_Hjoerring, "DistributionCenter", "Danmark", "Jylland", "Hjørring" },

                    // =========================
                    // DISTRIBUTION CENTERS – SJÆLLAND
                    // =========================
                    { TerminalSeedIds.DC_Roskilde, "DistributionCenter", "Danmark", "Sjælland", "Roskilde" },
					{ TerminalSeedIds.DC_Koege, "DistributionCenter", "Danmark", "Sjælland", "Køge" },
					{ TerminalSeedIds.DC_Hillerod, "DistributionCenter", "Danmark", "Sjælland", "Hillerød" },
					{ TerminalSeedIds.DC_Slagelse, "DistributionCenter", "Danmark", "Sjælland", "Slagelse" },
					{ TerminalSeedIds.DC_Naestved, "DistributionCenter", "Danmark", "Sjælland", "Næstved" },

                    // =========================
                    // DISTRIBUTION CENTERS – FYN
                    // =========================
                    { TerminalSeedIds.DC_Odense, "DistributionCenter", "Danmark", "Fyn", "Odense" },
					{ TerminalSeedIds.DC_Svendborg, "DistributionCenter", "Danmark", "Fyn", "Svendborg" },

                    // =========================
                    // DISTRIBUTION CENTERS – BORNHOLM
                    // =========================
                    { TerminalSeedIds.DC_Roenne, "DistributionCenter", "Danmark", "Bornholm", "Rønne" },

                    // =========================
                    // PICKUP POINTS – SJÆLLAND
                    // =========================
                    { TerminalSeedIds.PP_Koebenhavn, "PickupPoint", "Danmark", "Sjælland", "København" },
					{ TerminalSeedIds.PP_Frederiksberg, "PickupPoint", "Danmark", "Sjælland", "Frederiksberg" },
					{ TerminalSeedIds.PP_Glentofte, "PickupPoint", "Danmark", "Sjælland", "Gentofte" },
					{ TerminalSeedIds.PP_Helsingoer, "PickupPoint", "Danmark", "Sjælland", "Helsingør" },
					{ TerminalSeedIds.PP_Helsingor, "PickupPoint", "Danmark", "Sjælland", "Helsingør" },
					{ TerminalSeedIds.PP_Slagelse, "PickupPoint", "Danmark", "Sjælland", "Slagelse" },
					{ TerminalSeedIds.PP_Naestved, "PickupPoint", "Danmark", "Sjælland", "Næstved" },
					{ TerminalSeedIds.PP_Ringsted, "PickupPoint", "Danmark", "Sjælland", "Ringsted" },

                    // =========================
                    // PICKUP POINTS – JYLLAND
                    // =========================
                    { TerminalSeedIds.PP_Aarhus, "PickupPoint", "Danmark", "Jylland", "Aarhus" },
					{ TerminalSeedIds.PP_Randers, "PickupPoint", "Danmark", "Jylland", "Randers" },
					{ TerminalSeedIds.PP_Viborg, "PickupPoint", "Danmark", "Jylland", "Viborg" },
					{ TerminalSeedIds.PP_Silkeborg, "PickupPoint", "Danmark", "Jylland", "Silkeborg" },
					{ TerminalSeedIds.PP_Horsens, "PickupPoint", "Danmark", "Jylland", "Horsens" },
					{ TerminalSeedIds.PP_Esbjerg, "PickupPoint", "Danmark", "Jylland", "Esbjerg" },
					{ TerminalSeedIds.PP_Herning, "PickupPoint", "Danmark", "Jylland", "Herning" },
					{ TerminalSeedIds.PP_Holstebro, "PickupPoint", "Danmark", "Jylland", "Holstebro" },
					{ TerminalSeedIds.PP_Aalborg, "PickupPoint", "Danmark", "Jylland", "Aalborg" },
					{ TerminalSeedIds.PP_Hjoerring, "PickupPoint", "Danmark", "Jylland", "Hjørring" },
					{ TerminalSeedIds.PP_Frederikshavn, "PickupPoint", "Danmark", "Jylland", "Frederikshavn" },

                    // =========================
                    // PICKUP POINTS – FYN & BORNHOLM
                    // =========================
                    { TerminalSeedIds.PP_Odense, "PickupPoint", "Danmark", "Fyn", "Odense" },
					{ TerminalSeedIds.PP_Svendborg, "PickupPoint", "Danmark", "Fyn", "Svendborg" },
					{ TerminalSeedIds.PP_Nyborg, "PickupPoint", "Danmark", "Fyn", "Nyborg" },
					{ TerminalSeedIds.PP_Middelfart, "PickupPoint", "Danmark", "Fyn", "Middelfart" },
					{ TerminalSeedIds.PP_Roenne, "PickupPoint", "Danmark", "Bornholm", "Rønne" }
				}
			);
		}
	}
}
