using Dapr.Client;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.Infrastructure.InfrastructureErrors;
using TerminalService.UseCase.InfrastructureInterfaces;
using TerminalService.UseCase.InfrastructureInterfaces.Contracts;

namespace TerminalService.Infrastructure.Messages
{
	public sealed class DaprPublisher : IPublisher
	{
		private readonly DaprClient _daprClient;
		private const string _pubSubName = "daprpubsub";

		public DaprPublisher(DaprClient daprClient)
		{
			_daprClient = daprClient;
		}

		public async Task<Result> PublishAllocationRequestSucces(AllocationRequestSucces allocationRequestSucces)
		{
			try
			{
				await _daprClient.PublishEventAsync(_pubSubName, "allocation-received", allocationRequestSucces);
				Console.WriteLine($"Published allocation-received event for {allocationRequestSucces.TrackingNumber} at terminal with id:{allocationRequestSucces.TerminalId}");
				return Result.Success();
			}
			catch (Exception)
			{
				return MessageError.MessagePublishError();
			}
		}

		public async Task<Result> PublishAllocationRequestFailed(AllocationRequestFailed allocationRequestFailed)
		{
			try
			{
				await _daprClient.PublishEventAsync(_pubSubName, "allocation-failed", allocationRequestFailed);
				return Result.Success();
			}
			catch (Exception)
			{
				return MessageError.MessagePublishError();
			}
		}
	}
}
