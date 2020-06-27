using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class GenreRespository : IGenreRespository
    {
        private readonly ERPContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public GenreRespository(ERPContext context)
        {
            _context = context;
        }

        public Genre Add(Genre genre)
        {
            return _context.Genres.Add(genre).Entity;
        }

        public async Task<IEnumerable<Genre>> GetAsync()
        {
            return await _context.Genres
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Genre> GetQuery()
        {
            return _context.Genres
                .AsNoTracking();
        }

        public async Task<Genre> GetAsync(Guid id)
        {
            Genre genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return null;
            }

            _context.Entry(genre).State = EntityState.Detached;
            return genre;
        }
    }
}
