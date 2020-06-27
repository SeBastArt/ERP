using ERP.Domain.Mappers;
using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRespository _artistRespository;
        private readonly IItemRespository _itemRespository;
        private readonly IArtistMapper _artistMapper;
        private readonly IItemMapper _itemMapper;

        public ArtistService(
            IArtistRespository artistRespository,
            IItemRespository itemRespository,
            IArtistMapper artistMapper,
            IItemMapper itemMapper)
        {
            _artistRespository = artistRespository;
            _itemRespository = itemRespository;
            _artistMapper = artistMapper;
            _itemMapper = itemMapper;
        }

        public async Task<ArtistResponse> AddArtistAsync(AddArtistRequest request)
        {
            Artist item = new Artist
            {
                ArtistName = request.ArtistName
            };

            Artist result = _artistRespository.Add(item);
            await _artistRespository.UnitOfWork.SaveChangesAsync();
            return _artistMapper.Map(result);
        }

        public async Task<ArtistResponse> GetArtistAsync(GetArtistRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            Artist result = await _artistRespository.GetAsync(request.Id);
            return result == null ? null : _artistMapper.Map(result);
        }

        public async Task<IEnumerable<ArtistResponse>> GetArtistsAsync()
        {
            IEnumerable<Artist> result = await _artistRespository.GetAsync();
            return result.Select(_artistMapper.Map);
        }

        public IQueryable<ArtistResponse> GetArtistsQuery()
        {
            IQueryable<Artist> result = _artistRespository.GetQuery();
            return result.Select(x => _artistMapper.Map(x));
        }

        public async Task<IEnumerable<ItemResponse>> GetItemByArtistIdAsync(GetArtistRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<Item> result = await _itemRespository.GetItemsByArtistIdAsync(request.Id);
            return result.Select(_itemMapper.Map);
        }
    }
}
