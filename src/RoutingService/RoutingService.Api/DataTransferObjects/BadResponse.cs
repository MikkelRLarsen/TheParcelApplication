namespace RoutingService.Api.DataTransferObjects
{
    public class BadResponse
    {
        public BadResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
