using ERP.Fixtures.Logging;
using ERP.Infrastructur;
using ERP.Infrastructure.Tests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace ERP.Fixtures
{
    public class InMemoryWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private ITestOutputHelper _testOutputHelper;
        public void SetTestOutputHelper(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseEnvironment("Testing")
                .ConfigureTestServices(services =>
                {
                    DbContextOptions<ERPContext> options = new DbContextOptionsBuilder<ERPContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                    if (_testOutputHelper != null)
                    {
                        services.AddLogging(cfg => cfg.AddProvider(new TestOutputLoggerProvider(_testOutputHelper)));
                    }

                    services.AddScoped<ERPContext>(serviceProvider => new TestERPContext(options));
                    services.Replace(ServiceDescriptor.Scoped(_ => new UsersContextFactory().InMemoryUserManager));

                    ServiceProvider sp = services.BuildServiceProvider();

                    using IServiceScope scope = sp.CreateScope();
                    IServiceProvider scopedServices = scope.ServiceProvider;
                    ERPContext db = scopedServices.GetRequiredService<ERPContext>();
                    db.Database.EnsureCreated();
                });
        }
    }
}
