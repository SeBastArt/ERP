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


    public class GenreRespositoryTests : IClassFixture<ERPContextFactory>
    {
        private readonly ERPContextFactory _factory;

        public GenreRespositoryTests(ERPContextFactory factory)
        {
            _factory = factory;
        }

        [Theory]
        [LoadData("genre")]
        public async Task Should_return_record_by_id(Genre genre)
        {
            GenreRespository _genreContext = new GenreRespository(_factory.ContextInstance);

            Genre result = await _genreContext.GetAsync(genre.GenreId);

            result.GenreId.ShouldBe(genre.GenreId);
            result.GenreDescription.ShouldBe(genre.GenreDescription);
        }

        [Theory]
        [LoadData("genre")]
        public async Task Should_add_new_item(Genre genre)
        {
            genre.GenreId = Guid.NewGuid();
            GenreRespository _genreContext = new GenreRespository(_factory.ContextInstance);
            _genreContext.Add(genre);

            await _genreContext.UnitOfWork.SaveEntitiesAsync();
            _factory.ContextInstance.Genres
                .FirstOrDefault(x => x.GenreId == genre.GenreId)
                .ShouldNotBeNull();
        }


    }
}
