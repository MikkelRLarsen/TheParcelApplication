using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.Domain.ValueObjects
{
	public abstract class Entity
	{
		protected Entity(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; protected set; }
	}
}
