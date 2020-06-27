using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System.Linq;

namespace ERP.Domain.Mappers
{
    public class ItemMapper : IItemMapper
    {
        private readonly IArtistMapper _artistMapper;
        private readonly IGenreMapper _genreMapper;

        public ItemMapper(IArtistMapper artistMapper, IGenreMapper genreMapper)
        {
            _artistMapper = artistMapper;
            _genreMapper = genreMapper;
        }

        public Item Map(AddItemRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Item item = new Item
            {
                Name = request.Name,
                Description = request.Description,
                LabelName = request.LabelName,
                PictureUri = request.PictureUri,
                ReleaseDate = request.ReleaseDate,
                Format = request.Format,
                AvailableStock = request.AvailableStock,
                GenreId = request.GenreId,
                ArtistId = request.ArtistId
            };

            if (request.Price != null)
            {
                item.Price = new Price
                {
                    Currency = request.Price.Currency,
                    Amount = request.Price.Amount
                };
            }

            return item;
        }

        public Item Map(EditItemRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Item item = new Item
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                LabelName = request.LabelName,
                PictureUri = request.PictureUri,
                ReleaseDate = request.ReleaseDate,
                Format = request.Format,
                AvailableStock = request.AvailableStock,
                GenreId = request.GenreId,
                ArtistId = request.ArtistId,
            };

            if (request.Price != null)
            {
                item.Price = new Price { Currency = request.Price.Currency, Amount = request.Price.Amount };
            }

            return item;
        }

        public ItemResponse Map(Item item)
        {
            if (item == null)
            {
                return null;
            };

            ItemResponse response = new ItemResponse
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                LabelName = item.LabelName,
                PictureUri = item.PictureUri,
                ReleaseDate = item.ReleaseDate,
                Format = item.Format,
                AvailableStock = item.AvailableStock,
                GenreId = item.GenreId,

                Genre = _genreMapper.Map(item.Genre),
                ArtistId = item.ArtistId,
                Artist = _artistMapper.Map(item.Artist)
            };

            if (item.Price != null)
            {
                response.Price = new PriceResponse
                {
                    Currency = item.Price.Currency,
                    Amount = item.Price.Amount
                };
            };

            return response;
        }

        public IQueryable<ItemResponse> Map(IQueryable<Item> item)
        {

            if (item == null)
            {
                return null;
            };

            IQueryable<ItemResponse> response = item.Select(x => new ItemResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                LabelName = x.LabelName,
                Price = new PriceResponse() { Amount = x.Price.Amount, Currency = x.Price.Currency },
                PictureUri = x.PictureUri,
                ReleaseDate = x.ReleaseDate,
                Format = x.Format,
                AvailableStock = x.AvailableStock,
                GenreId = x.GenreId,
                ArtistId = x.ArtistId,
                IsInactive = x.IsInactive,
            });

            return response;
        }
    }
}
