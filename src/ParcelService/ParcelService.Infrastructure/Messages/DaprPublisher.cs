using ParcelService.Domain.Entities;
using ParcelService.UseCase.InfrastructureInterfaces.Ports;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Dapr.Client;
using ParcelService.Infrastructure.InfrastructureErrors;
using System.Diagnostics.CodeAnalysis;
using ParcelService.UseCase.InfrastructureInterfaces.Contracts;

namespace ParcelService.Infrastructure.Messages
{
    public class DaprPublisher : INewParcelPublisher
    {
        private readonly DaprClient _daprClient;
        private const string _pubSubName = "daprpubsub";
        private const string _topic = "new-parcel";

        public DaprPublisher(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        // Consider outbox pattern, if time at the end of project
        public async Task<Result> PublishNewParcelEvent(NewParcelEvent newParcelEvent)
        {
			try
            {
                await _daprClient.PublishEventAsync(_pubSubName, _topic, newParcelEvent);
                return Result.Success();
            }
            catch (Exception)
            {
                return MessageError.MessagePublishError(newParcelEvent);
            }
        }
	}
}
