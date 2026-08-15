using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using Company.FunctionApp1.Extensions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();
builder.Services.AddSwashBuckle((options) =>
{
    options.RoutePrefix = "api";
    options.SpecVersion = OpenApiSpecVersion.OpenApi3_0;
    options.PrependOperationWithRoutePrefix = true;
    options.AddNewtonsoftSupport = true;
    options.Documents = new[]
    {
        new SwaggerDocument
        {
            Name = "v1",
            Title = "My API",
            Description = "My Azure Functions API",
            Version = "v1"
        }
    };
    options.Title = "My API";
});
builder.Services.Configure<WorkerOptions>((options) =>
{
    options.InputConverters.Register<QueryParamsConverter>();
});

builder.Build().Run();