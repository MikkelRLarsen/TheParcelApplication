using RoutingService.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase.SpecificationPattern
{
	public sealed class MainAreaSpecification : ISpecification<Terminal>
	{
		private readonly string _mainAreaTarget;
		private readonly ISpecification<Terminal>[] _andSpecs;
		private readonly Guid _fromId;
		private readonly Guid _toId;

		public MainAreaSpecification(string mainAreaTarget, Guid fromId, Guid toId,
			params ISpecification<Terminal>[] andSpecs)
		{
			_mainAreaTarget = mainAreaTarget;
			_fromId = fromId;
			_toId = toId;
			_andSpecs = andSpecs ?? Array.Empty<ISpecification<Terminal>>();
		}

		public ISpecification<Terminal> And(ISpecification<Terminal> spec)
		{
			return new MainAreaSpecification(
				_mainAreaTarget,
				_fromId,
				_toId,
				_andSpecs.Append(spec).ToArray()
			);
		}

		public IQueryable<Terminal> Apply(IQueryable<Terminal> query)
		{
			query = query.Where(t =>
				(
					t.Region.MainRegion == _mainAreaTarget &&
					t.Type != TerminalType.PickupPoint
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
