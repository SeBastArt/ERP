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
    public class GenreService : IGenreService
    {
        private readonly IGenreRespository _genreRespository;
        private readonly IItemRespository _itemRespository;
        private readonly IGenreMapper _genreMapper;
        private readonly IItemMapper _itemMapper;

        public GenreService(IGenreRespository genreRespository, IItemRespository itemRespository,
            IGenreMapper genreMapper, IItemMapper itemMapper)
        {
            _genreRespository = genreRespository;
            _itemRespository = itemRespository;
            _genreMapper = genreMapper;
            _itemMapper = itemMapper;
        }

        public IQueryable<GenreResponse> GetGenresQuery()
        {
            IQueryable<Genre> result = _genreRespository.GetQuery();
            return result.Select(x => _genreMapper.Map(x));
        }

        public async Task<IEnumerable<GenreResponse>> GetGenresAsync()
        {
            IEnumerable<Genre> result = await _genreRespository.GetAsync();
            return result.Select(x => _genreMapper.Map(x));
        }

        public async Task<GenreResponse> GetGenreAsync(GetGenreRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            Genre result = await _genreRespository.GetAsync(request.Id);
            return result == null ? null : _genreMapper.Map(result);
        }

        public async Task<IEnumerable<ItemResponse>> GetItemByGenreIdAsync(GetGenreRequest request)
        {
            if (request?.Id == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<Item> result = await _itemRespository.GetItemsByGenreIdAsync(request.Id);
            return result.Select(_itemMapper.Map);
        }

        public async Task<GenreResponse> AddGenreAsync(AddGenreRequest request)
        {
            Genre item = new Genre { GenreDescription = request.GenreDescription };

            Genre result = _genreRespository.Add(item);
            await _genreRespository.UnitOfWork.SaveChangesAsync();

            return _genreMapper.Map(result);
        }
    }
}