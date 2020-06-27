using ERP.Domain.Models;
using ERP.Fixtures;
using ERP.Infrastructur;
using ERP.Infrastructur.Respositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ERP.Infrastructure.Tests
{
    public class ItemRespositoryTests : IClassFixture<ERPContextFactory>
    {
        private readonly ItemRespository _itemRespository;
        private readonly TestERPContext _context;

        public ItemRespositoryTests(ERPContextFactory catlogContextFactory)
        {
            _context = catlogContextFactory.ContextInstance;
            _itemRespository = new ItemRespository(_context);
        }

        [Fact]
        public async Task should_get_data()
        {
            System.Collections.Generic.IEnumerable<Item> result = await _itemRespository.GetAsync();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task should_returns_null_with_id_not_present()
        {
            Item result = await _itemRespository.GetAsync(Guid.NewGuid());
            result.ShouldBeNull();
        }


        [Theory]
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90e")]
        public async Task should_return_record_by_id(string guid)
        {
            DbContextOptions<ERPContext> options = new DbContextOptionsBuilder<ERPContext>()
                .UseInMemoryDatabase(databaseName: "should_return_record_by_id")
                .Options;

            await using TestERPContext context = new TestERPContext(options);
            context.Database.EnsureCreated();

            ItemRespository sut = new ItemRespository(context);
            Item result = await sut.GetAsync(new Guid(guid));

            result.Id.ShouldBe(new Guid(guid));
        }

        [Fact]
        public async Task should_add_new_item()
        {
            Item testItem = new Item
            {
                Name = "Test album",
                Description = "Description",
                LabelName = "Label name",
                Price = new Price { Amount = 13, Currency = "EUR" },
                PictureUri = "https://mycdn.com/pictures/32423423",
                ReleaseDate = DateTimeOffset.Now,
                Format = "Vinyl 33g",
                AvailableStock = 6,
                GenreId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6"),
                ArtistId = new Guid("f08a333d-30db-4dd1-b8ba-3b0473c7cdab")
            };


            _itemRespository.Add(testItem);
            await _itemRespository.UnitOfWork.SaveEntitiesAsync();

            _context.Items
                .FirstOrDefault(item => item.Id == testItem.Id)
                .ShouldNotBeNull();
        }

        [Fact]
        public async Task should_update_item()
        {
            Item testItem = new Item
            {
                Id = new Guid("f5da5ce4-091e-492e-a70a-22b073d75a52"),
                Name = "Test album",
                Description = "Description updated",
                LabelName = "Label name",
                Price = new Price { Amount = 50, Currency = "EUR" },
                PictureUri = "https://mycdn.com/pictures/32423423",
                ReleaseDate = DateTimeOffset.Now,
                Format = "Vinyl 33g",
                AvailableStock = 6,
                GenreId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6"),
                ArtistId = new Guid("f08a333d-30db-4dd1-b8ba-3b0473c7cdab")
            };

            _itemRespository.Update(testItem);

            await _itemRespository.UnitOfWork.SaveEntitiesAsync();

            Item result = _context.Items
                .FirstOrDefault(item => item.Id == testItem.Id);

            result.Description.ShouldBe("Description updated");
            result.Price.Amount.ShouldBe(50);
        }

    }
}
