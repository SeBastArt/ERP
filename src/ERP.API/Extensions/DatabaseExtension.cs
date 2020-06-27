using ERP.Infrastructur;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.API.Extensions
{
    /// <summary>
    /// DatabaseExtension
    /// </summary>
    public static class DatabaseExtension
    {
        /// <summary>
        /// AddERPContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IServiceCollection AddERPContext(this IServiceCollection services, string connectionString)
        {
            return services
               //.AddEntityFrameworkSqlServer()
               .AddDbContext<ERPContext>(contextOptions =>
               {
                   contextOptions.UseSqlServer(connectionString, serverOptions =>
                   {
                       serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                   });
               });
        }
    }
}
