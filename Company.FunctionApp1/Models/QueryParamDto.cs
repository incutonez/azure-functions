using Company.FunctionApp1.Extensions;
using Microsoft.Azure.Functions.Worker.Converters;

namespace Company.FunctionApp1.Models;

[InputConverter(typeof(QueryParamsConverter))]
public class QueryParamDto
{
    // Intentionally left empty, as it's mostly used to set up the InputConverter and key off of in QueryParamsOperationFilter    
}