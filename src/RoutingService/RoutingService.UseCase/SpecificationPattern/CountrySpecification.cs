using RoutingService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.SpecificationPattern
{
	internal class CountrySpecification : ISpecification<Terminal>
	{
		private readonly string _fromMainRegion;
		private readonly string _toMainRegion;
		private readonly ISpecification<Terminal>[] _andSpecs;
		private readonly Guid _fromId;
		private readonly Guid _toId;

		public CountrySpecification(string fromMainRegion, string toMainRegion, Guid fromId, Guid toId,
			params ISpecification<Terminal>[] andSpecs)
		{
			_fromMainRegion = fromMainRegion;
			_toMainRegion = toMainRegion;
			_fromId = fromId;
			_toId = toId;
			_andSpecs = andSpecs ?? Array.Empty<ISpecification<Terminal>>();
		}

		public ISpecification<Terminal> And(ISpecification<Terminal> spec)
		{
			return new CountrySpecification(
				_fromMainRegion,
				_toMainRegion,
				_fromId,
				_toId,
				_andSpecs.Append(spec).ToArray()
			);
		}

		public IQueryable<Terminal> Apply(IQueryable<Terminal> query)
		{
			query = query.Where(t =>
				(
					t.Type == TerminalType.DistributionCenter && 
					(
						t.Region.MainRegion == _fromMainRegion ||
						t.Region.MainRegion == _toMainRegion
					)
				)

				|| t.Id == _fromId
				|| t.Id == _toId
				|| t.Type == TerminalType.Hub
			);

			foreach (var spec in _andSpecs)
			{
				query = spec.Apply(query);
			}

			return query;
		}
	}
}
