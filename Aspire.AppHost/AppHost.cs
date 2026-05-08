using CommunityToolkit.Aspire.Hosting.Dapr;
using System;
using System.Collections.Immutable;


namespace Aspire.AppHost
{
    public class AppHost
    {
        public static void Main(string[] args)
        {
            var builder = DistributedApplication.CreateBuilder(args);

            var daprResources = ImmutableHashSet.Create("../Docs/AspireDaprComponents");

            // Name postgres-db is the same as the headless postgres service set in kubernetes deployment manifest
            var postgres = builder.AddPostgres("postgres-db")
                .WithLifetime(ContainerLifetime.Persistent)
                .WithPgAdmin();

            // Name redis-db is the same as the headless redis service set in kubernetes deployment manifest
            var redis = builder.AddRedis("redis-db")
                .WithLifetime(ContainerLifetime.Session)
                .WithHttpEndpoint(6379, isProxied: false)
                .WithRedisInsight();

            ServiceBuildingBlocks buildingBlock = new ServiceBuildingBlocks(
                postgres: postgres,
                daprResources: daprResources,
                redis: redis);

            builder.ParcelService(buildingBlock);
            builder.RoutingService(buildingBlock);
            builder.TerminalService(buildingBlock);

            // Add Dapr Dashboard
            builder.AddExecutable(
                "dapr-dashboard",   
                "dapr",            
                ".",                
                "dashboard",        
                "-p", "9060"        
            );


            builder.Build().Run();
        }
    }

    public static class SetupServices
    {
        public static void ParcelService(this IDistributedApplicationBuilder builder, ServiceBuildingBlocks block)
        {
            var parcelDb = block.postgres.AddDatabase("parceldb");

            var parcelService = builder.AddProject<Projects.ParcelService_Api>("parcelservice")
                .WithReference(parcelDb)
                .WithDaprSidecar(new DaprSidecarOptions
                {
                    AppId = "parcelservice",
                    DaprHttpPort = 8081,
                    ResourcesPaths = block.daprResources
                })
                .WaitFor(parcelDb);
        }

        public static void RoutingService(this IDistributedApplicationBuilder builder, ServiceBuildingBlocks block)
        {
            var routingDb = block.postgres.AddDatabase("routingdb");

            var routingService = builder.AddProject<Projects.RoutingService_Api>("routingservice")
                .WithReference(routingDb)
                .WithDaprSidecar(new DaprSidecarOptions
                {
                    AppId = "routingservice",
                    DaprHttpPort = 8082,
                    ResourcesPaths = block.daprResources
                })
                .WaitFor(routingDb);
        }

		public static void TerminalService(this IDistributedApplicationBuilder builder, ServiceBuildingBlocks block)
		{
			var terminalDb = block.postgres.AddDatabase("terminaldb");

			var terminalService = builder.AddProject<Projects.TerminalService_Api>("terminalservice")
				.WithReference(terminalDb)
				.WithDaprSidecar(new DaprSidecarOptions
				{
					AppId = "terminalservice",
					DaprHttpPort = 8083,
					ResourcesPaths = block.daprResources
				})
				.WaitFor(terminalDb);
		}
	}

    public record ServiceBuildingBlocks
    {
        public ServiceBuildingBlocks(IResourceBuilder<PostgresServerResource> postgres, IResourceBuilder<RedisResource> redis, ImmutableHashSet<string> daprResources)
        {
            this.postgres = postgres;
            this.redis = redis;
            this.daprResources = daprResources;
        }

        public IResourceBuilder<PostgresServerResource> postgres { get; init; }
        public IResourceBuilder<RedisResource> redis { get; init; }
        public ImmutableHashSet<string> daprResources { get; init; }
    }
}