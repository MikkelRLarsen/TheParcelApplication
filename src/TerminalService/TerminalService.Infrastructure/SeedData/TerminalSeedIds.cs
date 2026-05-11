using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Infrastructure.SeedData
{
	public static class TerminalSeedIds
	{
		// Hubs
		public static readonly Guid Hub_CPH = Guid.Parse("10000000-0000-0000-0000-000000000001");
		public static readonly Guid Hub_Vejle = Guid.Parse("10000000-0000-0000-0000-000000000002");

		// =========================
		// DISTRIBUTION CENTERS
		// =========================
		// Jylland
		public static readonly Guid DC_Aarhus = Guid.Parse("20000000-0000-0000-0000-000000000001");
		public static readonly Guid DC_Aalborg = Guid.Parse("20000000-0000-0000-0000-000000000002");
		public static readonly Guid DC_Esbjerg = Guid.Parse("20000000-0000-0000-0000-000000000003");
		public static readonly Guid DC_Herning = Guid.Parse("20000000-0000-0000-0000-000000000004");
		public static readonly Guid DC_Horsens = Guid.Parse("20000000-0000-0000-0000-000000000005");
		public static readonly Guid DC_Viborg = Guid.Parse("20000000-0000-0000-0000-000000000006");
		public static readonly Guid DC_Randers = Guid.Parse("20000000-0000-0000-0000-000000000007");
		public static readonly Guid DC_Hjoerring = Guid.Parse("20000000-0000-0000-0000-000000000008");

		// Sjælland
		public static readonly Guid DC_Roskilde = Guid.Parse("20000000-0000-0000-0000-000000000009");
		public static readonly Guid DC_Koege = Guid.Parse("20000000-0000-0000-0000-000000000010");
		public static readonly Guid DC_Hillerod = Guid.Parse("20000000-0000-0000-0000-000000000011");
		public static readonly Guid DC_Slagelse = Guid.Parse("20000000-0000-0000-0000-000000000012");
		public static readonly Guid DC_Naestved = Guid.Parse("20000000-0000-0000-0000-000000000013");

		// Fyn
		public static readonly Guid DC_Odense = Guid.Parse("20000000-0000-0000-0000-000000000014");
		public static readonly Guid DC_Svendborg = Guid.Parse("20000000-0000-0000-0000-000000000015");

		// Bornholm
		public static readonly Guid DC_Roenne = Guid.Parse("20000000-0000-0000-0000-000000000016");

		// =========================
		// PICKUP POINTS
		// =========================
		// København / Sjælland
		public static readonly Guid PP_Koebenhavn = Guid.Parse("30000000-0000-0000-0000-000000000001");
		public static readonly Guid PP_Frederiksberg = Guid.Parse("30000000-0000-0000-0000-000000000002");
		public static readonly Guid PP_Glentofte = Guid.Parse("30000000-0000-0000-0000-000000000003");
		public static readonly Guid PP_Helsingoer = Guid.Parse("30000000-0000-0000-0000-000000000004");
		public static readonly Guid PP_Helsingor = Guid.Parse("30000000-0000-0000-0000-000000000005");
		public static readonly Guid PP_Slagelse = Guid.Parse("30000000-0000-0000-0000-000000000006");
		public static readonly Guid PP_Naestved = Guid.Parse("30000000-0000-0000-0000-000000000007");
		public static readonly Guid PP_Ringsted = Guid.Parse("30000000-0000-0000-0000-000000000008");

		// Jylland øst
		public static readonly Guid PP_Aarhus = Guid.Parse("30000000-0000-0000-0000-000000000009");
		public static readonly Guid PP_Randers = Guid.Parse("30000000-0000-0000-0000-000000000010");
		public static readonly Guid PP_Viborg = Guid.Parse("30000000-0000-0000-0000-000000000011");
		public static readonly Guid PP_Silkeborg = Guid.Parse("30000000-0000-0000-0000-000000000012");
		public static readonly Guid PP_Horsens = Guid.Parse("30000000-0000-0000-0000-000000000013");

		// Jylland vest
		public static readonly Guid PP_Esbjerg = Guid.Parse("30000000-0000-0000-0000-000000000014");
		public static readonly Guid PP_Herning = Guid.Parse("30000000-0000-0000-0000-000000000015");
		public static readonly Guid PP_Holstebro = Guid.Parse("30000000-0000-0000-0000-000000000016");

		// Nordjylland
		public static readonly Guid PP_Aalborg = Guid.Parse("30000000-0000-0000-0000-000000000017");
		public static readonly Guid PP_Hjoerring = Guid.Parse("30000000-0000-0000-0000-000000000018");
		public static readonly Guid PP_Frederikshavn = Guid.Parse("30000000-0000-0000-0000-000000000019");

		// Fyn
		public static readonly Guid PP_Odense = Guid.Parse("30000000-0000-0000-0000-000000000020");
		public static readonly Guid PP_Svendborg = Guid.Parse("30000000-0000-0000-0000-000000000021");
		public static readonly Guid PP_Nyborg = Guid.Parse("30000000-0000-0000-0000-000000000022");
		public static readonly Guid PP_Middelfart = Guid.Parse("30000000-0000-0000-0000-000000000023");

		// Bornholm
		public static readonly Guid PP_Roenne = Guid.Parse("30000000-0000-0000-0000-000000000024");

		// Ekstra til skalering
		public static readonly Guid PP_Kolding = Guid.Parse("30000000-0000-0000-0000-000000000025");
		public static readonly Guid PP_Vejle = Guid.Parse("30000000-0000-0000-0000-000000000026");
		public static readonly Guid PP_Faaborg = Guid.Parse("30000000-0000-0000-0000-000000000027");
		public static readonly Guid PP_Nakskov = Guid.Parse("30000000-0000-0000-0000-000000000028");
		public static readonly Guid PP_Kalundborg = Guid.Parse("30000000-0000-0000-0000-000000000029");
		public static readonly Guid PP_Holbaek = Guid.Parse("30000000-0000-0000-0000-000000000030");
		public static readonly Guid PP_Greve = Guid.Parse("30000000-0000-0000-0000-000000000031");
		public static readonly Guid PP_Ballerup = Guid.Parse("30000000-0000-0000-0000-000000000032");
	}
}
