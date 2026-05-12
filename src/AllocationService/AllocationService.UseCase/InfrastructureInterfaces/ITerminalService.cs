using AllocationService.Domain;
using AllocationService.UseCase.Contracts;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.InfrastructureInterfaces
{
	public interface ITerminalService
	{
		public Task<ResultT<Terminal>> Get(Guid terminalId);
	}
}
