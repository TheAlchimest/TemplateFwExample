//using Microsoft.OpenApi.Any;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace TemplateFwExample.Shared.Configuration
{
    //public class OpenApiIgnoreEnumSchemaFilter : ISchemaFilter
    //{
    //    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    //    {
    //        if (context.Type.IsEnum)
    //        {
    //            var enumOpenApiStrings = new List<IOpenApiAny>();

    //            foreach (var enumValue in Enum.GetValues(context.Type))
    //            {
    //                var member = context.Type.GetMember(enumValue.ToString())[0];
    //                if (!member.GetCustomAttributes<OpenApiIgnoreEnumAttribute>().Any())
    //                {
    //                    enumOpenApiStrings.Add(new OpenApiString(enumValue.ToString()));
    //                }
    //            }

    //            schema.Enum = enumOpenApiStrings;
    //        }
    //    }
    //}

    public class OpenApiIgnoreEnumAttribute : Attribute
    {
    }
}
