using AllocationService.Facade;
using AllocationService.Infrastructure.External;
using AllocationService.Infrastructure.Messages;
using AllocationService.UseCase;
using AllocationService.UseCase.AllocationServices;
using AllocationService.UseCase.InfrastructureInterfaces;
using AllocationService.UseCase.QueueFactories;
using AllocationService.UseCase.TerminalResolvers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AllocationService.InversionOfControl
{
    public static class BuilderExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Commands
            services.AddScoped<IAllocateRequestCommand, AllocateRequestCommand>();

            // UseCase Helpers
            services.AddScoped<IAllocationService, AllocationServiceHandler>();
            services.AddSingleton<IQueueFactory, QueueFactory>();
            services.AddScoped<ITerminalResolver, TerminalResolver>();

            // Infrastructure
            services.AddScoped<ICacheHandler, DaprStatestoreHandler>();
            services.AddScoped<IPublisher, DaprPublisher>();
            services.AddScoped<ITerminalService, TerminalService>();

            

            return services;
        }
    }
}
