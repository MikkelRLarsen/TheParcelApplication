using RoutingService.Domain;
using RoutingService.UseCase.GraphEntities;
using RoutingService.UseCase.RoutingAlgoritme;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RoutingService.UseCase.RoutingStrategy
{
	public sealed class RoutingStrategyPipeline : IRoutingStrategyPipeline
	{
		private readonly IEnumerable<IRoutingStrategy> _strategies;

		public RoutingStrategyPipeline(IEnumerable<IRoutingStrategy> strategies)
		{
			_strategies = strategies.OrderByDescending(s => s.Order);
		}

		/// <summary>
		/// Executes registered pipeline strategies for the specified source and destination terminals and returns the first
		/// successful graph result.
		/// </summary>
		/// <remarks>Strategies are evaluated in order; the method awaits each strategy's TryExecute and returns
		/// immediately on the first success. If no strategy supports the terminals a BadRequest failure is
		/// returned.</remarks>
		/// <param name="from">Source terminal to evaluate.</param>
		/// <param name="to">Destination terminal to evaluate.</param>
		/// <returns>A task that yields a ResultT<Graph> containing the successful graph when a strategy succeeds; otherwise a failure
		/// result with a BadRequest error (code 'PIPELINE.ERROR').</returns>
		public async Task<ResultT<IRoutePath>> ExecuteAsync(Terminal from, Terminal to)
		{
			foreach (var strategy in _strategies)
			{
				if (strategy.CanHandle(from, to) is false)
					continue;

				var result = await strategy.TryExecute(from, to);
				if (result.Status is ResultStatus.Success)
					return result;
			}

			return ResultT<IRoutePath>.Failure(Error.BadRequest("PIPELINE.ERROR", "No strategy supports this package"));
		}
	}
}
