using ParcelService.Domain.Entities;
using ParcelService.Facade.Commands;
using ParcelService.Facade.DataTransferObjects;
using ParcelService.UseCase.InfrastructureInterfaces.Contracts;
using ParcelService.UseCase.InfrastructureInterfaces.Ports;
using ParcelService.UseCase.InfrastructureInterfaces.Repositories;
using ParcelService.UseCase.Mappers;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.UseCase.Commands
{
    public class CreateParcelCommand : ICreateParcelCommand
    {
        private readonly IParcelRepository _repository;
        private readonly INewParcelPublisher _publisher;

        public CreateParcelCommand(IParcelRepository repository, INewParcelPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        /// <summary>
        /// Takes commanddto transform to domain object Parcel and creates an row of Parcel in database
        /// </summary>
        /// <param name="command"></param>
        /// <returns>A generic ResultT. Remeber to check result status</returns>
        public async Task<ResultT<CreateParcelCommandResponse>> Handle(CreateParcelCommandDto command)
        {
            ResultT<Parcel> mappingResult = command.MapToParcel();
            if (mappingResult.Status is ResultStatus.Failure) 
                return mappingResult.Error!;

            Parcel parcel = mappingResult.Value;

            Result databaseResult = await _repository.CreateParcelAsync(parcel);
            if (databaseResult.Status is ResultStatus.Failure) 
                return databaseResult.Error!;

            Result saveChangesResult = await _repository.SaveAsync();
            if (saveChangesResult.Status is ResultStatus.Failure)
                return saveChangesResult.Error!;

            Result publishResult = await _publisher.PublishNewParcelEvent(new NewParcelEvent(parcel));
            if (publishResult.Status is ResultStatus.Success)
                return new CreateParcelCommandResponse(parcel.Tracking.TrackingNumber);
            else
                return publishResult.Error!;
        }
    }
}
