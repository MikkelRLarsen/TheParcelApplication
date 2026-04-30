using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.Mappers
{
    public static class MappingError
    {
        public static Error MappingFailure(string description) => 
            Error.BadRequest("Mapping.Failed", description);      
    }
}
