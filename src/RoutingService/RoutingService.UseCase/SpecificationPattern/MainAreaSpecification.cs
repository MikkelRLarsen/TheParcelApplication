using RoutingService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.SpecificationPattern
{
	public sealed class MainAreaSpecification : ISpecification<Terminal>
	{
		private readonly string _mainRegionTarget;
		private readonly ISpecification<Terminal>[] _andSpecs;
		private readonly Guid _fromId;
		private readonly Guid _toId;

		public MainAreaSpecification(string mainRegionTarget, Guid fromId, Guid toId,
			params ISpecification<Terminal>[] andSpecs)
		{
			_mainRegionTarget = mainRegionTarget;
			_fromId = fromId;
			_toId = toId;
			_andSpecs = andSpecs ?? Array.Empty<ISpecification<Terminal>>();
		}

		public ISpecification<Terminal> And(ISpecification<Terminal> spec)
		{
			return new MainAreaSpecification(
				_mainRegionTarget,
				_fromId,
				_toId,
				_andSpecs.Append(spec).ToArray()
			);
		}

		public IQueryable<Terminal> Apply(IQueryable<Terminal> query)
		{
			query = query.Where(t =>
				(
					t.Region.MainRegion == _mainRegionTarget &&
					t.Type != TerminalType.PickupPoint
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
