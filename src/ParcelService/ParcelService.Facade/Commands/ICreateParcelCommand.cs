using ParcelService.Facade.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.ResultPattern;

namespace ParcelService.Facade.Commands
{
    public interface ICreateParcelCommand
    {
        public Task<ResultT<CreateParcelCommandResponse>> Handle(CreateParcelCommandDto command);
    }
}
