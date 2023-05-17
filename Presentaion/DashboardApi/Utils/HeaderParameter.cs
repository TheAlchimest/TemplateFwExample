using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TemplateFwExample.DashboardApi.Utils
{
    public class HeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            var language = new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Description = "Supported languages",

                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String",
                    Default = new OpenApiString("ar")
                }
            };

            var user = new OpenApiParameter
            {
                Name = "user",
                In = ParameterLocation.Header,
                Description = "user",

                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String",
                }
            };
            operation.Parameters.Add(language);
            operation.Parameters.Add(user);
        }
    }
}
