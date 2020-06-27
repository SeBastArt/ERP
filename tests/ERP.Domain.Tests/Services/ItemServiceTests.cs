using ERP.Domain.Mappers;
using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using ERP.Fixtures;
using ERP.Infrastructur.Respositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ERP.Domain.Tests
{
    public class ItemServiceTests : IClassFixture<ERPContextFactory>
    {
        private readonly ItemRespository _itemRespository;
        private readonly GenreRespository _genreRespository;
        private readonly ArtistRespository _artistRespository;
        private readonly IItemMapper _itemMapper;
        private readonly Mock<LoggerAbstraction<IItemService>> _logger;

        public ItemServiceTests(ERPContextFactory catalogContextFactory, ITestOutputHelper testOutputHelper)
        {
            _itemRespository = new ItemRespository(catalogContextFactory.ContextInstance);
            _genreRespository = new GenreRespository(catalogContextFactory.ContextInstance);
            _artistRespository = new ArtistRespository(catalogContextFactory.ContextInstance);
            _itemMapper = catalogContextFactory.ItemMapper;
            _logger = new Mock<LoggerAbstraction<IItemService>>();
            _logger
                .Setup(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<Exception>(), It.IsAny<string>()))
                .Callback((LogLevel logLevel, Exception exception, string information) => testOutputHelper.WriteLine($"{logLevel}:{information}"));
        }

        [Fact]
        public async Task Getitems_should_return_right_data()
        {
            ItemService itemService = new ItemService(_itemRespository, _genreRespository, _artistRespository, _itemMapper, _logger.Object);

            System.Collections.Generic.IEnumerable<ItemResponse> result = await itemService.GetItemsAsync();

            result.ShouldNotBeNull();
        }

        [Theory]
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90e")]
        public async Task Getitem_should_return_right_data(string guid)
        {
            ItemService itemService = new ItemService(_itemRespository, _genreRespository, _artistRespository, _itemMapper, _logger.Object);
            ItemResponse result =
                await itemService.GetItemAsync(new Guid(guid));

            result.Id.ShouldBe(new Guid(guid));
        }

        [Fact]
        public async Task Additem_should_add_right_entity()
        {
            AddItemRequest testItem = new AddItemRequest
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

            IItemService itemService = new ItemService(_itemRespository, _genreRespository, _artistRespository, _itemMapper, _logger.Object);

            ItemResponse result = await itemService.AddItemAsync(testItem);

            result.Name.ShouldBe(testItem.Name);
            result.Description.ShouldBe(testItem.Description);
            result.GenreId.ShouldBe(testItem.GenreId);
            result.ArtistId.ShouldBe(testItem.ArtistId);
            result.Price.Amount.ShouldBe(testItem.Price.Amount);
            result.Price.Currency.ShouldBe(testItem.Price.Currency);
        }

        [Theory]
        [LoadData("item")]
        public async Task Additem_should_log_information(AddItemRequest request)
        {
            ItemService sut = new ItemService(_itemRespository, _genreRespository, _artistRespository, _itemMapper, _logger.Object);

            await sut.AddItemAsync(request);

            _logger
                .Verify(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<Exception>(), It.IsAny<string>()), Times.AtMost(2));
        }

        [Fact]
        public async Task Edititem_should_add_right_entity()
        {
            EditItemRequest testItem = new EditItemRequest
            {
                Id = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e"),
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

            ItemService itemService = new ItemService(_itemRespository, _genreRespository, _artistRespository, _itemMapper, _logger.Object);

            ItemResponse result = await itemService.EditItemAsync(testItem);

            result.Name.ShouldBe(testItem.Name);
            result.Description.ShouldBe(testItem.Description);
            result.GenreId.ShouldBe(testItem.GenreId);
            result.ArtistId.ShouldBe(testItem.ArtistId);
            result.Price.Amount.ShouldBe(testItem.Price.Amount);
            result.Price.Currency.ShouldBe(testItem.Price.Currency);
        }
    }
}
