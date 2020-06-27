using ERP.Domain.Models;
using ERP.Infrastructur;
using ERP.Infrastructure.Tests.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Tests
{
    public class TestERPContext : ERPContext
    {
        public TestERPContext(DbContextOptions<ERPContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed<Artist>("./Data/artist.json");
            modelBuilder.Seed<Genre>("./Data/genre.json");
            modelBuilder.Seed<Item>("./Data/item.json");
        }
    }
}
