using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using FastEndpoints;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerconfig)
    => loggerconfig.ReadFrom.Configuration(context.Configuration));

builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>()); Fichiers cachés
builder.Services.AddFastEndpoints();
WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.UseFastEndpoints();
app.Run();

public partial class Program;
