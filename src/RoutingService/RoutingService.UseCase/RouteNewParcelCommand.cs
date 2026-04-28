using RoutingService.Facade;
using RoutingService.Facade.DataTransferObjects;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoutingService.UseCase
{
	public sealed class RouteNewParcelCommand : IRouteNewParcelCommand
	{
		public Task<Result> Handle(RouteNewParcel command)
		{
			throw new NotImplementedException();
		}
	}
}
