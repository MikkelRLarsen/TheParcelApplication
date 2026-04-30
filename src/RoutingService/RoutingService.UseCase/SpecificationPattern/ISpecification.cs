using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.SpecificationPattern
{
	public interface ISpecification<T>
	{
		public IQueryable<T> Apply(IQueryable<T> query);
		public ISpecification<T> And(ISpecification<T> spec);
	}
}
