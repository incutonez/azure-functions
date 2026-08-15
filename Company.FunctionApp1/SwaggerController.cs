using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace Company.FunctionApp1;

public class SwaggerController(ISwashBuckleClient swashBuckleClient)
{
    [SwaggerIgnore]
    [Function("SwaggerJson")]
    public async Task<IActionResult> SwaggerJson(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Swagger/json")]
        HttpRequest req)
    {
        return await swashBuckleClient.CreateSwaggerJsonDocumentResult(req);
    }

    [SwaggerIgnore]
    [Function("SwaggerYaml")]
    public async Task<IActionResult> SwaggerYaml(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Swagger/yaml")]
        HttpRequest req)
    {
        return await swashBuckleClient.CreateSwaggerYamlDocumentResult(req);
    }

    [SwaggerIgnore]
    [Function("SwaggerUi")]
    public async Task<IActionResult> SwaggerUi(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Swagger/ui")]
        HttpRequest req)
    {
        return await swashBuckleClient.CreateSwaggerUIResult(req, "swagger/json");
    }
}