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
                Domain.ValueObjects.Destination destination =
                    new Domain.ValueObjects.Destination(
                        dto.Destination.Region,
                        dto.Destination.Terminal);

                Domain.ValueObjects.PersonInfo sender =
                    new Domain.ValueObjects.PersonInfo(
                        dto.Sender.Name,
                        new Domain.ValueObjects.Address(
                            dto.Sender.Address.Street,
                            dto.Sender.Address.HouseNumber,
                            dto.Sender.Address.City,
                            dto.Sender.Address.ZipCode,
                            dto.Sender.Address.Country));

                Domain.ValueObjects.PersonInfo reciever =
                    new Domain.ValueObjects.PersonInfo(
                        dto.Reciever.Name,
                        new Domain.ValueObjects.Address(
                            dto.Reciever.Address.Street,
                            dto.Reciever.Address.HouseNumber,
                            dto.Reciever.Address.City,
                            dto.Reciever.Address.ZipCode,
                            dto.Reciever.Address.Country));

                Parcel parcel = new Parcel(
                    dto.Weight,
                    dto.Priority,
                    destination,
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
