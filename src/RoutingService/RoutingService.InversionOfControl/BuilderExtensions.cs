using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoutingService.Facade;
using RoutingService.Infrastructure;
using RoutingService.Infrastructure.Repositories;
using RoutingService.UseCase;
using RoutingService.UseCase.InfrastructureInterfaces;
using RoutingService.UseCase.RoutingAlgoritme;
using RoutingService.UseCase.RoutingStrategy;

namespace RoutingService.InversionOfControl
{
	public static class BuilderExtensions
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.SetupDatabase(configuration);

			//Commands
			services.AddScoped<IRouteNewParcelCommand, RouteNewParcelCommand>();

			// Pipeline
			services.AddScoped<IRoutingStrategyPipeline, RoutingStrategyPipeline>();
			// Strategy
			services.AddScoped<IRoutingStrategy, MainAreaStrategy>();
			services.AddScoped<IRoutingStrategy, SubAreaStrategy>();
			services.AddScoped<IRoutingStrategy, CountryStrategy>();
			// Algorithm
			services.AddScoped<IRouteAlgoritme, Dijsktra>();
			
			// Infrastructure
			services.AddScoped<ITerminalRepository, TerminalRepository>();

			return services;
		}

		private static IServiceCollection SetupDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<EFAppContext>(options =>
			{
				options.UseNpgsql(
					configuration.GetConnectionString("routingdb"),
					npgsqlOptions => npgsqlOptions.MigrationsAssembly("RoutingService.Infrastructure")
				);
			});

			return services;
		}

		public static WebApplication SetupDatabaseOnColdStart(this WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<EFAppContext>();

				// Check and apply pending migrations
				var pendingMigrations = dbContext.Database.GetPendingMigrations();
				if (pendingMigrations.Any())
				{
					Console.WriteLine("Applying pending migrations...");
					dbContext.Database.Migrate();
					Console.WriteLine("Migrations applied successfully.");
				}
				else
				{
					Console.WriteLine("No pending migrations found.");
				}
			}

			return app;
		}
	}
}
