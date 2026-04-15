using ParcelService.Api.DataTransferObjects;
using ParcelService.Facade.Commands;
using ParcelService.Facade.DataTransferObjects;
using Shared.ResultPattern;
using static ParcelService.Api.Middleware.ApiExceptions;

namespace ParcelService.Api.Controllers
{
    public class ParcelControllerImplementation : IParcelController
    {
        private readonly ICreateParcelCommand _createParcelCommand;
        private readonly HttpContext _httpContext;
        private readonly ILogger<ParcelControllerImplementation> _logger;

        public ParcelControllerImplementation(ICreateParcelCommand createParcelCommand, IHttpContextAccessor contextAccessor)
        {
            _createParcelCommand = createParcelCommand;
            _httpContext = contextAccessor.HttpContext;
        }

        public async Task<CreateParcelResponse> CreateParcelAsync(CreateParcelRequest body)
        {
            ResultT<CreateParcelCommandResponse> result = await _createParcelCommand.Handle(body.Map());

            if(result.Status is ResultStatus.Success)
            {
                CreateParcelResponse reponse = CreateParcelResponse.MapResponse(result.Value);

                _httpContext.Response.StatusCode = StatusCodes.Status201Created;
                return reponse;
            }

            switch (result.Error.ErrorType)
            {
                case ErrorType.BadRequest:
                    _logger.LogError($"A request returned 400 => {result.Error.Code}");
                    throw new BadRequest(result.Error.Description);

                default:
                    _logger.LogError($"A request returned 500 => {result.Error.Code}");
                    throw new InternalException(result.Error.Description);
            }
        }
    }
}
