using ParcelService.Api.Middleware;
using Scalar.AspNetCore;
using Shared;

namespace Template.Api;

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
		builder.Services.AddScoped<IParcelController, ParcelControllerImplementation>();

		var app = builder.Build();

		app.SetupDatabaseOnColdStart();

		// Configure the HTTP request pipeline.
		app.UseExceptionHandler();

		app.UseHttpsRedirection();

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
