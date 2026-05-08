using Dapr.Client;
using RoutingService.Infrastructure.InfrastructureErrors;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.InfrastructureInterfaces.Contracts;
using Shared.ResultPattern;

namespace RoutingService.Infrastructure.Messages
{
	public sealed partial class DaprPublisher : IPublisher
	{
		private readonly DaprClient _daprClient;
		private const string _pubSubName = "daprpubsub";
		private const string _topic = "allocate-parcel";

		public DaprPublisher(DaprClient daprClient)
		{
			_daprClient = daprClient;
		}

		public async Task<Result> PublishAllocationRequest(AllocateRequestV1 request)
		{
			try
			{
				await _daprClient.PublishEventAsync(_pubSubName, _topic, request);
				Console.WriteLine("Published allocation request for tracking number: {0}", request.TrackingNumber);
				return Result.Success();
			}
			catch (Exception)
			{
				return MessageError.MessagePublishError();
			}
		}
	}
}
