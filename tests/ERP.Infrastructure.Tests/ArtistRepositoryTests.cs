using ERP.Domain.Models;
using ERP.Fixtures;
using ERP.Infrastructur.Respositories;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ERP.Infrastructure.Tests
{
    public class ArtistRespositoryTests : IClassFixture<ERPContextFactory>
    {
        private readonly ERPContextFactory _factory;

        public ArtistRespositoryTests(ERPContextFactory factory)
        {
            _factory = factory;
        }

        [Theory]
        [LoadData("artist")]
        public async Task Should_return_record_by_id(Artist artist)
        {
            ArtistRespository _artistContext = new ArtistRespository(_factory.ContextInstance);

            Artist result = await _artistContext.GetAsync(artist.ArtistId);

            result.ArtistId.ShouldBe(artist.ArtistId);
            result.ArtistName.ShouldBe(artist.ArtistName);
        }

        [Theory]
        [LoadData("artist")]
        public async Task should_add_new_item(Artist artist)
        {
            artist.ArtistId = Guid.NewGuid();
            ArtistRespository _artistContext = new ArtistRespository(_factory.ContextInstance);
            _artistContext.Add(artist);

            await _artistContext.UnitOfWork.SaveEntitiesAsync();
            _factory.ContextInstance.Artist
                .FirstOrDefault(x => x.ArtistId == artist.ArtistId)
                .ShouldNotBeNull();
        }
    }
}
