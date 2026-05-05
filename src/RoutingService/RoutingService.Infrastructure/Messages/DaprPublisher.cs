using Dapr.Client;
using RoutingService.Infrastructure.InfrastructureErrors;
using RoutingService.UseCase.InfrastructureInterfaces;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace RoutingService.Infrastructure.Messages
{
	public sealed class DaprPublisher : IPublisher
	{
		private readonly DaprClient _daprClient;
		private const string _pubSubName = "daprpubsub";
		private const string _topic = "allocate-parcel";

		public DaprPublisher(DaprClient daprClient)
		{
			_daprClient = daprClient;
		}

		public async Task<Result> PublishAllocationRequest(Guid trackingNumber, IEnumerable<Guid> terminals, int priority)
		{
			// Create object
			AllocateRequest request = new AllocateRequest(trackingNumber, terminals, priority);

			try
			{
				await _daprClient.PublishEventAsync(_pubSubName, _topic, request);
				Console.WriteLine("Published allocation request for tracking number: {0}", trackingNumber);
				return Result.Success();
			}
			catch (Exception)
			{
				return MessageError.MessagePublishError();
			}
		}

		private record AllocateRequest
		{
			[SetsRequiredMembers]
			public AllocateRequest(Guid trackingNumber, IEnumerable<Guid> terminals, int priority)
			{
				TrackingNumber = trackingNumber;
				Terminals = terminals;
				Priority = priority;
			}

			public required Guid TrackingNumber { get; init; }
			public required IEnumerable<Guid> Terminals { get; init; }
			public required int Priority { get; init; }
		}
	}
}
