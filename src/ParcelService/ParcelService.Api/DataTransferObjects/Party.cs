using System;
using System.Collections.Generic;
using System.Text;
using ParcelService.Facade.DataTransferObjects;

namespace ParcelService.Api.DataTransferObjects
{
	public record Party
	{
		public required Guid TerminalId { get; init; }
		public required PersonInfo PersonalInformation { get; init; }

		public ParcelService.Facade.DataTransferObjects.Party Map()
		{
			return new Facade.DataTransferObjects.Party(
				terminalId: TerminalId,
				personalInformation: PersonalInformation.Map()
				);
		}
	}
}
