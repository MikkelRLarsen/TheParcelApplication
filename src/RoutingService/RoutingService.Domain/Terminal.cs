using RoutingService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoutingService.Domain
{
	public class Terminal : Entity
	{
		private Terminal(Guid id) : base(id)
		{
		}
		public static implicit operator Terminal(Guid id) => new Terminal(id);		
	}
}
