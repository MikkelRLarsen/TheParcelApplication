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
				SenderTerminal = new Terminal(
					id: parcel.Sender.Terminal.Id,
					region: new Region(
						country: parcel.Sender.Terminal.Region.Country,
						mainRegion: parcel.Sender.Terminal.Region.MainRegion,
						subRegion: parcel.Sender.Terminal.Region.SubRegion));

				ReceiverTerminal = new Terminal(
					id: parcel.Receiver.Terminal.Id,
					region: new Region(
						country: parcel.Receiver.Terminal.Region.Country,
						mainRegion: parcel.Receiver.Terminal.Region.MainRegion,
						subRegion: parcel.Receiver.Terminal.Region.SubRegion));

				Priority = parcel.Priority;
			}

			public Guid TrackingNumber { get; init; }

			public Terminal SenderTerminal { get; init; }

			public Terminal ReceiverTerminal { get; init; }

			public int Priority { get; init; }
		}

		private sealed record Terminal
		{
			public Terminal(Guid id, Region region)
			{
				Id = id;
				Region = region;
			}

			public Guid Id { get; init; }

			public Region Region { get; init; }
		}

		private sealed record Region
		{
			public Region(string country, string mainRegion, string subRegion)
			{
				Country = country;
				MainRegion = mainRegion;
				SubRegion = subRegion;
			}

			public string Country { get; init; } = null!;

			public string MainRegion { get; init; } = null!;

			public string SubRegion { get; init; } = null!;
		}
	}
}
