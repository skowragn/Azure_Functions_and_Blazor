using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using CarsManager.Application.Services;
using CarsManager.Functions.API.Extensions;
using Microsoft.Extensions.Configuration;
using CarsManager.Infrastructure.Configuration;
using CarsManager.Infrastructure.Extensions;
using CarsManager.Application.Validators;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(worker => worker.UseNewtonsoftJson())
     .ConfigureAppConfiguration((context, builder) =>
     {
         builder.SetBasePath(context.HostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
     })
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddConfiguration(config);
        services.AddValidatorsFromAssembly(typeof(CarBookedItemRequestValidator).Assembly);
        services.AddMsSqlDatabase();
        services.AddRepositoriesServices();
        services.AddCqrs();
        services.AddLogging();
        services.InitDatabase();

        services.Configure<ConnectionStrings>(config.GetSection(nameof(ConnectionStrings)));
    })
    .Build();
host.Run();