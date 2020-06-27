using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ItemRespository : IItemRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ItemRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Item Add(Item item)
        {
            return _context.Items.Add(item).Entity;
        }

        public async Task<IEnumerable<Item>> GetAsync()
        {
            return await _context.Items
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Item> GetQuery()
        {
            return _context.Items
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            Item item = await _context.Items.AsNoTracking().Where(x => x.Id == id).Include(x => x.Genre).Include(x => x.Artist).FirstOrDefaultAsync();
            return item;
        }

        public Item Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return item;
        }

        public async Task<IEnumerable<Item>> GetItemsByArtistIdAsync(Guid id)
        {
            List<Item> items = await _context
                .Items
                .Where(x => !x.IsInactive)
                .Where(item => item.ArtistId == id)
                .Include(x => x.Genre)
                .Include(x => x.Artist)
                .ToListAsync();

            return items;
        }

        public async Task<IEnumerable<Item>> GetItemsByGenreIdAsync(Guid id)
        {
            List<Item> items = await _context.Items
                .Where(x => !x.IsInactive)
                .Where(item => item.GenreId == id)
                .Include(x => x.Genre)
                .Include(x => x.Artist)
                .ToListAsync();

            return items;
        }
    }
}
