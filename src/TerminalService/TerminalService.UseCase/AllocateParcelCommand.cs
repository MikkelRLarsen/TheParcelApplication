using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TerminalService.Domain.Entities;
using TerminalService.Facade;
using TerminalService.UseCase.InfrastructureInterfaces;
using TerminalService.UseCase.InfrastructureInterfaces.Contracts;
using TerminalService.UseCase.UseCaseErrors;

namespace TerminalService.UseCase
{
	public sealed class AllocateParcelCommand : IAllocateRequestCommand
	{
		private readonly ITerminalRepository _terminalRepository;
		private readonly IPublisher _publisher;

		public AllocateParcelCommand(ITerminalRepository terminalRepository, IPublisher publisher)
		{
			_terminalRepository = terminalRepository;
			_publisher = publisher;
		}

		public async Task<Result> TryHandle(AllocateRequest allocateParcel)
		{
			int retries = 0;

			while (retries++ < 3)
			{
				if(retries == 0)
					await Task.Delay(Random.Shared.Next(10, 50)); // To avoid Thundering Herd and Retry-Storm

				ResultT<TerminalDayStatus> projectionResult = await _terminalRepository
					.GetAllocationStatusAsync(allocateParcel.TerminalId, DateOnly.FromDateTime(DateTime.UtcNow));
				if (projectionResult.Status is ResultStatus.Failure)
					return projectionResult.Error!;

				TerminalDayStatus projection = projectionResult.Value;

				TerminalAllocation allocation = new TerminalAllocation(allocateParcel.TerminalId, allocateParcel.TrackingNumber, projection.GetNextVersion);

				Result allocateResult =	await _terminalRepository.AllocateParcelAsync(allocation);
				if (allocateResult.Status is ResultStatus.Failure)
					continue;

				Result saveResult = await _terminalRepository.SaveChangesAsync();
				if (saveResult.Status is ResultStatus.Failure)
					continue;

				return await _publisher.PublishAllocationRequestSucces(new AllocationRequestSucces(allocateParcel.TrackingNumber, allocateParcel.TerminalId));
			}

			Result result = await _publisher.PublishAllocationRequestFailed(new AllocationRequestFailed(allocateParcel.TrackingNumber, allocateParcel.TerminalId));
			if (result.Status is ResultStatus.Failure)
				return result;

			return Result.HandledError(AllocationError.NoMoreRetires(allocateParcel.TerminalId, allocateParcel.TrackingNumber));
		}
	}
}
