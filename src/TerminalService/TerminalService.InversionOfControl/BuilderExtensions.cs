using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TerminalService.Facade;
using TerminalService.Infrastructure;
using TerminalService.Infrastructure.Messages;
using TerminalService.Infrastructure.Repositories;
using TerminalService.UseCase;
using TerminalService.UseCase.InfrastructureInterfaces;

namespace TerminalService.InversionOfControl
{
	public static class BuilderExtensions
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.SetupDatabase(configuration);

			//Commands
			services.AddScoped<IAllocateRequestCommand, AllocateParcelCommand>();
			
			// Infrastructure
			services.AddScoped<ITerminalRepository, TerminalRepository>();
			services.AddScoped<IPublisher, DaprPublisher>();
			services.AddScoped<ICheckIfExistQuery, TerminalRepository>();
			services.AddHostedService<TerminalDailyResetService>();
			services.AddScoped<IUpdateTerminalCapacityQuery, UpdateTerminalCapacityQueryHandler>();

			return services;
		}

		private static IServiceCollection SetupDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<EFAppContext>(options =>
			{
				options.UseNpgsql(
					configuration.GetConnectionString("terminaldb"),
					npgsqlOptions => npgsqlOptions.MigrationsAssembly("TerminalService.Infrastructure")
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
