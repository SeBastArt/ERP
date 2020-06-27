using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ERP.API.Extensions.Swagger;

namespace ERP.API.Extensions.Swagger
{
    /// <summary>
    /// SwaggerExtension
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// AddSwagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services
               // Register the Swagger generator, defining 1 or more Swagger documents
               .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
               .AddSwaggerGen(options =>
               {
                   // [SwaggerRequestExample] & [SwaggerResponseExample]
                   // version < 3.0 like this: c.OperationFilter<ExamplesOperationFilter>(); 
                   // version 3.0 like this: c.AddSwaggerExamples(services.BuildServiceProvider());
                   // version > 4.0 like this:
                   options.ExampleFilters();

                   options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization                                                       // or use the generic method, e.g. c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<MyCustomAttribute>>();

                   // add Security information to each operation for OAuth2
                   options.OperationFilter<SecurityRequirementsOperationFilter>();
                   // or use the generic method, e.g. c.OperationFilter<SecurityRequirementsOperationFilter<MyCustomAttribute>>();

                   options.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });

                   options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                        {
                            new OpenApiSecurityScheme{
                                Reference = new OpenApiReference{
                                    Id = "Bearer", //The name of the previously defined security scheme.
                                    Type = ReferenceType.SecurityScheme
                                }
                            },new List<string>()
                        }
                    });


                   // add a custom operation filter which sets default values
                   options.OperationFilter<SwaggerDefaultValues>();

                   // integrate xml comments
                   options.IncludeXmlComments(XmlCommentsFilePath);
               })
                .AddSwaggerExamplesFromAssemblyOf<Startup>();
        }

        private static string XmlCommentsFilePath
        {
            get {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
