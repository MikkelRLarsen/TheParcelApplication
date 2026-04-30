using ParcelService.Domain.Entities;
using ParcelService.Infrastructure.DatabaseErrors;
using ParcelService.UseCase.InfrastructureInterfaces.Repositories;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Infrastructure.Repositories
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly EFAppContext _context;

        public ParcelRepository(EFAppContext context)
        {
            _context = context;
        }

        public async Task<Result> CreateParcelAsync(Parcel parcel)
        {
            try
            {
                await _context.Parcels.AddAsync(parcel);
                return Result.Success();
            }
            catch (Exception)
            {
                return DatabaseError.DatabaseCreateError(parcel);
            }   
        }

        public async Task<Result> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return Result.Success();
            }
            catch (Exception)
            {
                return DatabaseError.DatabaseSaveChangesError();
            }
        }
    }
}
