using Scalar.AspNetCore;
using Shared;
using TerminalService.Api.Controllers;
using TerminalService.Api.Middleware;
using TerminalService.InversionOfControl;

namespace TerminalService.Api;

public class Program
{
    public static void Main(string[] args)
    {
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers().AddDapr();
		builder.Services.AddHttpContextAccessor();

		builder.AddServiceDefaults();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddOpenApi();

		builder.Services.AddExceptionHandler<ApiExceptionHandler>();
		builder.Services.AddProblemDetails();

		builder.Services.RegisterServices(builder.Configuration);
		builder.Services.AddScoped<ITerminalController, TerminalControllerImplementation>();

		var app = builder.Build();

		app.SetupDatabaseOnColdStart();

		// Configure the HTTP request pipeline.
		app.UseExceptionHandler();

		app.UseCloudEvents();
		//app.UseHttpsRedirection();

		app.MapSubscribeHandler();

		app.UseAuthorization();

		app.MapControllers();

		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
			app.MapScalarApiReference();
		}

		app.Run();
	}
}
