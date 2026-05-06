using RoutingService.UseCase.GraphEntities;
using Shared.ResultPattern;

namespace RoutingService.UseCase.RoutingAlgoritme
{
	public interface IRouteAlgoritme
	{
		public ResultT<IRoutePath> Calculate(Graph graph, Guid startId, Guid needleId);
	}
}
