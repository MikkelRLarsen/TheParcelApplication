using RoutingService.Domain;
using RoutingService.Facade.DataTransferObjects;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace RoutingService.UseCase.Mappers
{
    public static class TerminalMapper
    {

        public static ResultT<Domain.Terminal> MapToDomainTerminal(this Facade.DataTransferObjects.Terminal dto)
        {
            try
            {
                return new Domain.Terminal(
                    id: dto.TerminalId,
                    region: new Domain.ValueObjects.Region(
                        country: dto.Region.Country,
                        mainRegion: dto.Region.MainRegion,
                        subRegion: dto.Region.SubRegion),
                    type: TerminalType.PickupPoint
                    );
            }
            catch (Exception)
            {
                return MappingError.MappingFailure("Mapping from RouteNewParcel to Terminal failed");
            }
        }
    }
}
