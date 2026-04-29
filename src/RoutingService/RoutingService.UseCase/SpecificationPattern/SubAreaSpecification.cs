using RoutingService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.SpecificationPattern
{
	public sealed class SubAreaSpecification : ISpecification<Terminal>
	{
		private readonly ISpecification<Terminal>[] _andSpecs;
		private readonly Tuple<Guid, Guid> TerminalIds;

		public SubAreaSpecification(Tuple<Guid, Guid> terminalIds,
			params ISpecification<Terminal>[] andSpecs)
		{
			_andSpecs = andSpecs ?? Array.Empty<ISpecification<Terminal>>();
		}

		public ISpecification<Terminal> And(ISpecification<Terminal> query)
		{
			throw new NotImplementedException();
		}

		public IQueryable<Terminal> Apply(IQueryable<Terminal> query)
		{
			foreach (var spec in _andSpecs)
			{
				query = spec.Apply(query);
			}

			return query;
		}
	}
}
