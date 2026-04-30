using RoutingService.Domain;
using RoutingService.UseCase.SpecificationPattern;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.InfrastructureInterfaces
{
	public interface ITerminalRepository
	{
		public Task<ResultT<IEnumerable<Terminal>>> GetAllAsync(ISpecification<Terminal> spec);
	}
}
