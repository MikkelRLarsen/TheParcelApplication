using RoutingService.Domain;

namespace RoutingService.UseCase.RoutingAlgoritme
{
	public interface IRoutePath
	{
		public Terminal Terminal { get; }
		public IReadOnlyCollection<IRoutePath> NextPotentielTerminals { get; }
	}
}
