using ParcelService.Domain.Entities;
using ParcelService.Domain.ValueObjects;
using ParcelService.Facade.DataTransferObjects;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace ParcelService.UseCase.Mappers
{
    public static class ParcelMapper
    {

        public static ResultT<Parcel> MapToParcel(this CreateParcelCommandDto dto)
        {
            try
            {
                Domain.ValueObjects.Party reciever =
                    new Domain.ValueObjects.Party(
                        terminalId: dto.Receiver.TerminalId,
                        personalInformation: new Domain.ValueObjects.PersonInfo(
                            name: dto.Receiver.PersonalInformation.Name,
                            address: new Domain.ValueObjects.Address(
                                street: dto.Receiver.PersonalInformation.Address.Street,
                                houseNumber: dto.Receiver.PersonalInformation.Address.HouseNumber,
                                city: dto.Receiver.PersonalInformation.Address.City,
                                zipCode: dto.Receiver.PersonalInformation.Address.ZipCode,
                                country: dto.Receiver.PersonalInformation.Address.Country)));

				Domain.ValueObjects.Party sender =
	                new Domain.ValueObjects.Party(
		                terminalId: dto.Sender.TerminalId,
		                personalInformation: new Domain.ValueObjects.PersonInfo(
			                name: dto.Sender.PersonalInformation.Name,
			                address: new Domain.ValueObjects.Address(
				                street: dto.Sender.PersonalInformation.Address.Street,
				                houseNumber: dto.Sender.PersonalInformation.Address.HouseNumber,
				                city: dto.Sender.PersonalInformation.Address.City,
				                zipCode: dto.Sender.PersonalInformation.Address.ZipCode,
				                country: dto.Sender.PersonalInformation.Address.Country)));


				Parcel parcel = new Parcel(
                    dto.Weight,
                    dto.Priority,
                    sender,
                    reciever);

                return parcel;
            }
            catch (Exception)
            {
                return MappingError.MappingFailure("Mapping from CreateParcelCommandDto to Parcel failed");
            }
        }
    }
}
