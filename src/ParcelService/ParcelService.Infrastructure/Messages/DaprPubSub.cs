using ParcelService.Domain.Entities;
using ParcelService.UseCase.InfrastructureInterfaces.Ports;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Dapr.Client;
using ParcelService.Infrastructure.InfrastructureErrors;

namespace ParcelService.Infrastructure.Messages
{
    public class DaprPubSub : INewParcelPublisher
    {
        private readonly DaprClient _daprClient;
        private const string _pubSubName = "daprpubsub";
        private const string _topic = "new-parcel";

        public DaprPubSub(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task<Result> PublishNewParcelEvent(Parcel parcel)
        {

			NewParcelEvent newParcelEvent = new NewParcelEvent(parcel);

			try
            {
                await _daprClient.PublishEventAsync(_pubSubName, _topic, newParcelEvent);
                return Result.Success();
            }
            catch (Exception)
            {
                return MessageError.MessagePublishError(parcel);
            }
        }

		private sealed record NewParcelEvent
		{
			public NewParcelEvent(Parcel parcel)
			{
				TrackingNumber = parcel.Tracking.TrackingNumber;
                SenderTerminal = parcel.Sender.Terminal.Id;
                ReceiverTerminal = parcel.Receiver.Terminal.Id;
				Priority = parcel.Priority;
			}

			public Guid TrackingNumber { get; init; }

			public Guid SenderTerminal { get; init; }

			public Guid ReceiverTerminal { get; init; }

			public int Priority { get; init; }
		}
	}
}
