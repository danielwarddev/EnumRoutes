using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EnumRoutes;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
        {
            return;
        }

        schema.Enum.Clear();

        foreach(var name in Enum.GetNames(context.Type))
        {
            schema.Enum.Add(new OpenApiString(name));
        }
    }
}
