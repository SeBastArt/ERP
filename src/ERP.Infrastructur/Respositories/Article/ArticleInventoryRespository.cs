using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArticleInventoriyRespository : IArticleInventoryRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticleInventoriyRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArticleInventory Add(ArticleInventory articleInventoriy)
        {
            return _context.ArticleInventories.Add(articleInventoriy).Entity;
        }

        public async Task<IEnumerable<ArticleInventory>> GetAsync()
        {
            return await _context.ArticleInventories
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<ArticleInventory> GetQuery()
        {
            return _context.ArticleInventories
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<ArticleInventory> GetAsync(Guid id)
        {
            ArticleInventory articleInventoriy = await _context.ArticleInventories.AsNoTracking().Where(x => x.Id == id).Include(x => x.ArticlePlace).FirstOrDefaultAsync();
            return articleInventoriy;
        }

        public ArticleInventory Update(ArticleInventory articleInventoriy)
        {
            _context.Entry(articleInventoriy).State = EntityState.Modified;
            return articleInventoriy;
        }
    }
}
