using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArticlePriceListOutRespository : IArticlePriceListOutRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticlePriceListOutRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArticlePriceListOut Add(ArticlePriceListOut articlePriceListOut)
        {
            return _context.ArticlePriceListsOut.Add(articlePriceListOut).Entity;
        }

        public async Task<IEnumerable<ArticlePriceListOut>> GetAsync()
        {
            return await _context.ArticlePriceListsOut
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<ArticlePriceListOut> GetQuery()
        {
            return _context.ArticlePriceListsOut
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<ArticlePriceListOut> GetAsync(Guid id)
        {
            ArticlePriceListOut articlePriceListOut = await _context.ArticlePriceListsOut.AsNoTracking().Where(x => x.Id == id).Include(x => x.Article).FirstOrDefaultAsync();
            return articlePriceListOut;
        }

        public ArticlePriceListOut Update(ArticlePriceListOut articlePriceListOut)
        {
            _context.Entry(articlePriceListOut).State = EntityState.Modified;
            return articlePriceListOut;
        }
    }
}
