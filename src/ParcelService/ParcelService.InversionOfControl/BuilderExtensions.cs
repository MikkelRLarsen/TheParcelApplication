using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParcelService.Facade.Commands;
using ParcelService.Infrastructure;
using ParcelService.Infrastructure.Messages;
using ParcelService.Infrastructure.Repositories;
using ParcelService.UseCase.Commands;
using ParcelService.UseCase.InfrastructureInterfaces.Ports;
using ParcelService.UseCase.InfrastructureInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.InversionOfControl
{
    public static class BuilderExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupDatabase(configuration);

            services.AddScoped<ICreateParcelCommand, CreateParcelCommand>();

            services.AddScoped<IParcelRepository, ParcelRepository>();
            services.AddScoped<INewParcelPublisher, DaprPublisher>();

            return services;
        }

        private static IServiceCollection SetupDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFAppContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("parceldb"),
                    npgsqlOptions => npgsqlOptions.MigrationsAssembly("ParcelService.Infrastructure")
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
