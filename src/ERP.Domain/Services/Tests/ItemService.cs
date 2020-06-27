using ERP.Domain.Extensions;
using ERP.Domain.Logging;
using ERP.Domain.Mappers;
using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Respositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRespository _itemRespository;
        private readonly IGenreRespository _genreRespository;
        private readonly IArtistRespository _artistRespository;
        private readonly IItemMapper _itemMapper;
        private readonly ILogger<IItemService> _logger;

        public ItemService(IItemRespository itemRespository, IGenreRespository genreRespository, IArtistRespository artistRespository, IItemMapper itemMapper, ILogger<IItemService> logger)
        {
            _itemRespository = itemRespository;
            _genreRespository = genreRespository;
            _artistRespository = artistRespository;
            _itemMapper = itemMapper;
            _logger = logger;
        }

        public async Task<ItemResponse> AddItemAsync(AddItemRequest request)
        {
            Item item = _itemMapper.Map(request);
            Item result = _itemRespository.Add(item);

            int modifiedRecords = await _itemRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return _itemMapper.Map(result);
        }

        public async Task<ItemResponse> DeleteItemAsync(DeleteItemRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            Item result = await _itemRespository.GetAsync(request.Id);

            if (result == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            result.IsInactive = true;

            _itemRespository.Update(result);
            int modifiedRecords = await _itemRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Delete, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);

            return _itemMapper.Map(result);
        }

        public async Task<ItemResponse> EditItemAsync(EditItemRequest request)
        {
            Item existingRecord = await _itemRespository.GetAsync(request.Id);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id} is not present");
            }

            Genre existingGenre = await _genreRespository.GetAsync(request.GenreId);
            if (existingGenre == null)
            {
                throw new NotFoundException($"Genre with {request.GenreId} is not present");
            }

            Artist existingArtist = await _artistRespository.GetAsync(request.ArtistId);
            if (existingArtist == null)
            {
                throw new NotFoundException($"Artist with {request.ArtistId} is not present");
            }

            Item entity = _itemMapper.Map(request);
            Item result = _itemRespository.Update(entity);

            int modifiedRecords = await _itemRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Logging.Events.Edit, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Logging.Events.Edit, Messages.ChangesApplied_id, result?.Id);

            return _itemMapper.Map(result);
        }

        public async Task<ItemResponse> GetItemAsync(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            Item entity = await _itemRespository.GetAsync(id);

            _logger.LogInformation(Events.GetById, Messages.TargetEntityChanged_id, entity?.Id);

            return _itemMapper.Map(entity);
        }

        public IQueryable<ItemResponse> GetItemsQuery()
        {
            //IQueryable<Item> result = _itemRespository.GetQuery();

            //return result.Select(x => new ItemResponse()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    LabelName = x.LabelName,
            //    Price = new PriceResponse() { Amount = x.Price.Amount, Currency = x.Price.Currency },
            //    PictureUri = x.PictureUri,
            //    ReleaseDate = x.ReleaseDate,
            //    Format = x.Format,
            //    AvailableStock = x.AvailableStock,
            //    GenreId = x.GenreId,
            //    ArtistId = x.ArtistId,
            //    IsInactive = x.IsInactive,
            //});

            IQueryable<Item> result = _itemRespository.GetQuery();
            return result.Select(x => _itemMapper.Map(x));
        }

        public async Task<IEnumerable<ItemResponse>> GetItemsAsync()
        {
            IEnumerable<Item> result = await _itemRespository.GetAsync();

            return result.Select(x => _itemMapper.Map(x));

        }
    }
}
