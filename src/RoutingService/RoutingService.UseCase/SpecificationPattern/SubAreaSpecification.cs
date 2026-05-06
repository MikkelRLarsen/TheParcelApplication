using RoutingService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.SpecificationPattern
{
	public sealed class SubAreaSpecification : ISpecification<Terminal>
	{
		private readonly string _subRegionTarget;
		private readonly Guid _fromId;
		private readonly Guid _toId;
		private readonly ISpecification<Terminal>[] _andSpecs;

		public SubAreaSpecification(
			string subRegionTarget,
			Guid fromId,
			Guid toId,
			params ISpecification<Terminal>[] andSpecs)
		{
			_subRegionTarget = subRegionTarget;
			_fromId = fromId;
			_toId = toId;
			_andSpecs = andSpecs ?? Array.Empty<ISpecification<Terminal>>();
		}


		public ISpecification<Terminal> And(ISpecification<Terminal> spec)
		{
			return new SubAreaSpecification(
				_subRegionTarget,
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

				   t.Region.SubRegion == _subRegionTarget
			   )
				|| t.Id == _fromId
				|| t.Id == _toId
			);

			foreach (var spec in _andSpecs)
			{
				query = spec.Apply(query);
			}

			return query;
		}
	}
}
