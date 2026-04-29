using System.Diagnostics.CodeAnalysis;

namespace RoutingService.Api.DataTransferObjects
{
    public class BadResponse
    {
        [SetsRequiredMembers]
        public BadResponse(string message)
        {
            Message = message;
        }

        public required string Message { get; init; }
    }
}
