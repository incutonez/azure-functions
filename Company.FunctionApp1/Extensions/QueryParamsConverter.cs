using Microsoft.Azure.Functions.Worker.Converters;
using Newtonsoft.Json;

namespace Company.FunctionApp1.Extensions;

// Idea taken from https://techiesweb.net/2023/02/11/azure-functions-input-converters.html
public class QueryParamsConverter : IInputConverter
{
    public async ValueTask<ConversionResult> ConvertAsync(ConverterContext context)
    {
        var source = context.FunctionContext.BindingContext.BindingData["Query"];
        if (source != null)
        {
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>((string) source);
            var model = Activator.CreateInstance(context.TargetType, dictionary);

            return ConversionResult.Success(model);
        }
        return ConversionResult.Failed(new Exception("FAILED!"));
    }
}