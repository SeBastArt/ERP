using ERP.Domain.Mappers;
using ERP.Infrastructur;
using ERP.Infrastructure.Tests;
using Microsoft.EntityFrameworkCore;
using System;

namespace ERP.Fixtures
{
    public class ERPContextFactory
    {
        public readonly TestERPContext ContextInstance;
        public readonly IGenreMapper GenreMapper;
        public readonly IArtistMapper ArtistMapper;
        public readonly IItemMapper ItemMapper;

        public ERPContextFactory()
        {
            DbContextOptions<ERPContext> contextOptions = new DbContextOptionsBuilder<ERPContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            EnsureCreation(contextOptions);
            ContextInstance = new TestERPContext(contextOptions);

            GenreMapper = new GenreMapper();
            ArtistMapper = new ArtistMapper();
            ItemMapper = new ItemMapper(ArtistMapper, GenreMapper);

        }

        private void EnsureCreation(DbContextOptions<ERPContext> contextOptions)
        {
            using TestERPContext context = new TestERPContext(contextOptions);
            context.Database.EnsureCreated();
        }
    }
}
