using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TimeKeeper.Api.Infrastructure
{
    public static class SwaggerExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            string[] reusedNames = { "Command", "Model", "Query" };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeKeeper.Api", Version = "v1" });
                c.CustomSchemaIds(type =>
                {
                    // if (reusedNames.Any(name => type.FullName.EndsWith($"+{name}")))
                    if (type.IsNested)
                    {
                        var parentNamespace =
                            type.Namespace[(type.Namespace.LastIndexOf(".", StringComparison.Ordinal) + 1)..];
                        var parentTypeName =
                            type.FullName[(type.FullName.LastIndexOf(".", StringComparison.Ordinal) + 1)..];

                        parentTypeName = reusedNames.Aggregate(parentTypeName, (current, name) =>
                            current.Replace($"+{name}", name));

                        return $"{parentNamespace}.{parentTypeName}";
                    }

                    return type.Name;
                });
            });
        }
    }
}