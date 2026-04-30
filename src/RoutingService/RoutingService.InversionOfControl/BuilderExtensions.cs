using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParcelService.Infrastructure;
using RoutingService.Facade;
using RoutingService.UseCase;

namespace RoutingService.InversionOfControl
{
	public static class BuilderExtensions
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.SetupDatabase(configuration);


			services.AddScoped<IRouteNewParcelCommand, RouteNewParcelCommand>();
			//services.AddScoped<ICreateParcelCommand, CreateParcelCommand>();

			//services.AddScoped<IParcelRepository, ParcelRepository>();
			//services.AddScoped<INewParcelPublisher, DaprPubSub>();

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
