using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArtistRespository : IArtistRespository
    {
        private readonly ERPContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ArtistRespository(ERPContext context)
        {
            _context = context;
        }

        public Artist Add(Artist artist)
        {
            return _context.Artist.Add(artist).Entity;
        }

        public async Task<IEnumerable<Artist>> GetAsync()
        {
            return await _context
                .Artist
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Artist> GetQuery()
        {
            return _context.Artist
                .AsNoTracking();
        }

        public async Task<Artist> GetAsync(Guid id)
        {
            Artist artist = await _context.Artist.FindAsync(id);

            if (artist == null)
            {
                return null;
            }

            _context.Entry(artist).State = EntityState.Detached;
            return artist;
        }
    }
}
