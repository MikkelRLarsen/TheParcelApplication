using ParcelService.Domain.Entities;
using ParcelService.UseCase.InfrastructureInterfaces.Contracts;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.UseCase.InfrastructureInterfaces.Ports
{
    public interface INewParcelPublisher
    {
        public Task<Result> PublishNewParcelEvent(NewParcelEvent newParcelEvent);
    }
}
