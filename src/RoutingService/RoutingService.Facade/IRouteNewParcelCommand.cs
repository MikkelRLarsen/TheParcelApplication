using System;
using System.Collections.Generic;
using System.Text;
using RoutingService.Facade.DataTransferObjects;
using Shared.ResultPattern;

namespace RoutingService.Facade
{
	public interface IRouteNewParcelCommand
	{
		public Task<Result> Handle(RouteNewParcel command);
	}
}
