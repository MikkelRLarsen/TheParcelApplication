using RoutingService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.SpecificationPattern
{
	public sealed class PickupPointSpecification : ISpecification<Terminal>
	{
		private readonly Guid _terminalGuid;
		private readonly ISpecification<Terminal>[] _andSpecs;

		public PickupPointSpecification(Guid terminalGuid, 
			params ISpecification<Terminal>[] andSpecs)
		{
			_terminalGuid = terminalGuid;
			_andSpecs = andSpecs ?? Array.Empty<ISpecification<Terminal>>();
		}

		public ISpecification<Terminal> And(ISpecification<Terminal> spec)
		{
			return new PickupPointSpecification(
				_terminalGuid,
				_andSpecs.Append(spec).ToArray()
			);
		}

		public IQueryable<Terminal> Apply(IQueryable<Terminal> query)
		{
			query = query.Where(t =>
				t.Id == _terminalGuid &&
				t.Type == TerminalType.PickupPoint);

			foreach (var spec in _andSpecs)
			{
				query = spec.Apply(query);
			}

			return query;
		}
	}
}
