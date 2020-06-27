using ERP.Domain.Mappers;
using ERP.Domain.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ERP.Domain.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            //Article
            services
                .AddSingleton<IArticlePriceListInMapper, ArticlePriceListInMapper>()
                .AddSingleton<IArticlePriceListOutMapper, ArticlePriceListOutMapper>()
                .AddSingleton<IArticleMapper, ArticleMapper>()
                .AddSingleton<IArticleGroupMapper, ArticleGroupMapper>()
                .AddSingleton<IArticleInventoryMapper, ArticleInventoryMapper>()
                .AddSingleton<IArticlePlaceMapper, ArticlePlaceMapper>()
                .AddSingleton<IArticleRangeMapper, ArticleRangeMapper>()
                .AddSingleton<IArticleTypeMapper, ArticleTypeMapper>();

            //Company
            services
                .AddSingleton<ICompanyMapper, CompanyMapper>()
                .AddSingleton<ICompanyTypeMapper, CompanyTypeMapper>()
                .AddSingleton<ICountryMapper, CountryMapper>()
                .AddSingleton<IPersonMapper, PersonMapper>();

            //Document
            services
                .AddSingleton<IDocumentMapper, DocumentMapper>()
                .AddSingleton<IDocumentPositionMapper, DocumentPositionMapper>();

            //Misc
            services
                .AddSingleton<IFAGBinaryMapper, FAGBinaryMapper>()
                .AddSingleton<IFAGTextMapper, FAGTextMapper>();

            //Tests
            services
                .AddSingleton<IArtistMapper, ArtistMapper>()
                .AddSingleton<IGenreMapper, GenreMapper>()
                .AddSingleton<IItemMapper, ItemMapper>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
               .AddSingleton<IArticlePriceListInService, ArticlePriceListInService>()
               .AddSingleton<IArticlePriceListOutService, ArticlePriceListOutService>()
               .AddSingleton<IArticleService, ArticleService>()
               .AddSingleton<IArticleGroupService, ArticleGroupService>()
               .AddSingleton<IArticleInventoryService, ArticleInventoryService>()
               .AddSingleton<IArticlePlaceService, ArticlePlaceService>()
               .AddSingleton<IArticleRangeService, ArticleRangeService>()
               .AddSingleton<IArticleTypeService, ArticleTypeService>();

            //Company
            services
                .AddSingleton<ICompanyService, CompanyService>()
                .AddSingleton<ICompanyTypeService, CompanyTypeService>()
                .AddSingleton<ICountryService, CountryService>()
                .AddSingleton<IPersonService, PersonService>();

            //Document
            services
                .AddSingleton<IDocumentService, DocumentService>()
                .AddSingleton<IDocumentPositionService, DocumentPositionService>();

            //Misc
            services
                .AddSingleton<IFAGBinaryService, FAGBinaryService>()
                .AddSingleton<IFAGTextService, FAGTextService>()
                .AddScoped<IUserService, UserService>();

            //Tests
            services
                .AddScoped<IItemService, ItemService>()
                .AddScoped<IArtistService, ArtistService>()
                .AddScoped<IGenreService, GenreService>();
    
            return services;
        }

        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder
                .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            return builder;
        }
    }
}
