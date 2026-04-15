using Microsoft.AspNetCore.Diagnostics;
using ParcelService.Api.DataTransferObjects;
using static ParcelService.Api.Middleware.ApiExceptions;

namespace ParcelService.Api.Middleware
{
    public class ApiExceptions
    {
        public class BadRequest : Exception
        {
            public BadRequest(string message) : base(message) { }
        }

        public class InternalException : Exception
        {
            public InternalException(string message) : base(message) { }
        }
    }

    public class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Initiate the specific NSwag-generated object
            BadResponse badResponse;
            int statusCode;

            switch (exception)
            {
                case BadRequest:
                    statusCode = StatusCodes.Status400BadRequest;
                    badResponse = new BadResponse(exception.Message);
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    badResponse = new BadResponse($"En uventet fejl skete");
                    break;
            }

            // Sets the status code
            httpContext.Response.StatusCode = statusCode;

            // Writes and sends the reponse as JSON back to the client
            await httpContext.Response.WriteAsJsonAsync(badResponse, cancellationToken);

            // Tells the program that the reponse has been sent
            return true;
        }
    }
}
