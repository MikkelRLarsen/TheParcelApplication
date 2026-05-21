using AllocationService.Infrastructure.InfrastructureErrors;
using AllocationService.UseCase.Contracts;
using AllocationService.UseCase.InfrastructureInterfaces;
using Dapr.Client;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.Infrastructure.Messages
{
	public sealed class DaprPublisher : IPublisher
	{
		private readonly DaprClient _daprClient;
		private const string _pubSubName = "daprpubsub";

		public DaprPublisher(DaprClient daprClient)
		{
			_daprClient = daprClient;
		}

		public async Task<Result> PublishAllocateParcelToTerminalAsync(ParcelToTerminalContract parcelToTerminalContract)
		{
			try
			{
				await _daprClient.PublishEventAsync(_pubSubName, "allcate-parcel-to-terminal", parcelToTerminalContract);
				Console.WriteLine($"Published allcate-parcel-to-terminal event for {parcelToTerminalContract.TrackingNumber} at terminal with id:{parcelToTerminalContract.TerminalId}");
				return Result.Success();
			}
			catch (Exception)
			{
				return MessageError.MessagePublishError();
			}
		}
	}
}
