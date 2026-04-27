using Aspire.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aspire.Integrationtest
{
    [CollectionDefinition("AspireApp")]
    public class AspireAppCollection : ICollectionFixture<AspireAppFixture>
    {
    }

    public static class AspireAppCollectionConsts
    {
        public const string Name = "Category";
        public const string Value = "Integration";
    }


    public class AspireAppFixture : IAsyncLifetime
    {

        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);
        private IDistributedApplicationTestingBuilder? _appHost;
        private DistributedApplication _app = null!;


        // This is an example. Use Services destribed in AppHost
        public HttpClient TemplateApi { get; private set; } = null!;
        public CancellationToken CancellationToken { get; private set; }

        public async Task DisposeAsync()
        {
            await _app.DisposeAsync();
        }

        public async Task InitializeAsync()
        {
            // Arrange

            var cts = new CancellationTokenSource(DefaultTimeout);
            CancellationToken = cts.Token;


            _appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Aspire_AppHost>(CancellationToken);
            _appHost.Services.AddLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Debug);
                // Override the logging filters from the app's configuration
                logging.AddFilter(_appHost.Environment.ApplicationName, LogLevel.Debug);
                logging.AddFilter("Aspire.", LogLevel.Debug);
                // To output logs to the xUnit.net ITestOutputHelper, consider adding a package from https://www.nuget.org/packages?q=xunit+logging
            });
            _appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
            {
                clientBuilder.AddStandardResilienceHandler();
            });

            _app = await _appHost.BuildAsync(CancellationToken).WaitAsync(DefaultTimeout, CancellationToken);
            await _app.StartAsync(CancellationToken).WaitAsync(DefaultTimeout, CancellationToken);

            await CreateHttpNamedClients();
        }

        private async Task CreateHttpNamedClients()
        {
            // This is an example. Use Services destribed in AppHost
            //TemplateApi = _app.CreateHttpClient("template-api");
            //await _app.ResourceNotifications.WaitForResourceHealthyAsync("template-api", CancellationToken);
        }
    }
}
