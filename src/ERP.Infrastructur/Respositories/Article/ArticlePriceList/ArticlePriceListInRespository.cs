using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArticlePriceListInRespository : IArticlePriceListInRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticlePriceListInRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArticlePriceListIn Add(ArticlePriceListIn articlePriceListIn)
        {
            return _context.ArticlePriceListsIn.Add(articlePriceListIn).Entity;
        }

        public async Task<IEnumerable<ArticlePriceListIn>> GetAsync()
        {
            return await _context.ArticlePriceListsIn
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<ArticlePriceListIn> GetQuery()
        {
            return _context.ArticlePriceListsIn
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<ArticlePriceListIn> GetAsync(Guid id)
        {
            ArticlePriceListIn articlePriceListIn = await _context.ArticlePriceListsIn.AsNoTracking().Where(x => x.Id == id).Include(x => x.Article).FirstOrDefaultAsync();
            return articlePriceListIn;
        }

        public ArticlePriceListIn Update(ArticlePriceListIn articlePriceListIn)
        {
            _context.Entry(articlePriceListIn).State = EntityState.Modified;
            return articlePriceListIn;
        }
    }
}
