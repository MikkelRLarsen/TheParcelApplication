using ParcelService.Facade.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using ParcelService.Domain.Entities;
using Shared.ResultPattern;

namespace ParcelService.UseCase.InfrastructureInterfaces
{
    public interface IParcelRepository
    {
        public Task<Result> CreateParcelAsync(Parcel parcel);
        public Task<Result> SaveAsync();
    }

}
