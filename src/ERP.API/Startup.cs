using ERP.API.Extensions;
using ERP.API.Extensions.Swagger;
using ERP.API.V1.Controllers;
using ERP.Domain.Extensions;
using ERP.Domain.Mediator.Queries;
using ERP.Domain.Responses;
using ERP.Domain.Respositories;
using ERP.Infrastructur.AuthorizationRequirements;
using ERP.Infrastructur.Extensions;
using ERP.Infrastructur.MediatRPipe;
using ERP.Infrastructur.Middleware;
using ERP.Infrastructur.Respositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RiskFirst.Hateoas;
using System.Security.Claims;

namespace ERP.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="currentEnvironment"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment currentEnvironment)
        {
            Configuration = configuration;
        }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddHttpContextAccessor();
            _ = services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UserIdPipe<,>));
            _ = services.AddMediatR(typeof(GetAllItemsQuery).Assembly);

            _ = services
                .AddTokenAuthentication(Configuration)
                .AddERPContext(Configuration.GetSection("DataSource:ConnectionString").Value)
                .AddScoped<IItemRespository, ItemRespository>()
                .AddScoped<IArtistRespository, ArtistRespository>()
                .AddScoped<IGenreRespository, GenreRespository>()
                .AddScoped<IUserRespository, UserRespository>()
                .AddMappers()
                .AddServices()
                .AddSwagger()
                .AddVersioning()
                .AddControllers()
                .AddValidation() // schau hier noch mal rein
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);

            
                
            _ = services.AddControllers().AddNewtonsoftJson(options =>
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            _ = services.Configure<IdentityOptions>(options =>
            {
                //Default Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            });

            _ = services.AddLinks(config =>
            {
                config.AddPolicy<HateoasResponse<ItemResponse>>(policy =>
                {
                    policy
                        .RequireRoutedLink(nameof(ItemsHateoasController.Get), nameof(ItemsHateoasController.Get))
                        .RequireRoutedLink(nameof(ItemsHateoasController.GetById), nameof(ItemsHateoasController.GetById), _ => new { id = _.Data.Id })
                        .RequireRoutedLink(nameof(ItemsHateoasController.Post), nameof(ItemsHateoasController.Post))
                        .RequireRoutedLink(nameof(ItemsHateoasController.Put), nameof(ItemsHateoasController.Put), x => new { id = x.Data.Id })
                        .RequireRoutedLink(nameof(ItemsHateoasController.Delete), nameof(ItemsHateoasController.Delete), x => new { id = x.Data.Id });
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5001")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            _ = env.IsDevelopment() ? app.UseDeveloperExceptionPage() : app.UseHsts();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            _ = app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            _ = app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            _ = app.UseRouting();
            _ = app.UseCors(MyAllowSpecificOrigins);
            _ = app.UseHttpsRedirection();
            _ = app.UseMiddleware<ResponseTimeMiddlewareAsync>();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
