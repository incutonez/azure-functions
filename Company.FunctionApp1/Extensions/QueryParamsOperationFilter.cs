using Company.FunctionApp1.Models;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Company.FunctionApp1.Extensions;

public class QueryParamsOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var queryParam = context.ApiDescription.ParameterDescriptions.FirstOrDefault((parameter) => typeof(QueryParamDto).IsAssignableFrom(parameter.Type));
        if (queryParam is null)
        {
            return;
        }

        operation.Parameters = new List<IOpenApiParameter>();
        foreach (var content in operation.RequestBody.Content)
        {
            // TODOJEF: TEST OUTPUT
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = queryParam.Name,
                Schema = content.Value.Schema,
                In = ParameterLocation.Query
                // Name = content.Value.Schema.Id,
                // Description = content.Value.Schema.Description,
                // In = ParameterLocation.Query
            });
        }
        operation.RequestBody = null;
    }
}