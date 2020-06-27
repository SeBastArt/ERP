using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArticleRangeRespository : IArticleRangeRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticleRangeRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArticleRange Add(ArticleRange articleRange)
        {
            return _context.ArticleRanges.Add(articleRange).Entity;
        }

        public async Task<IEnumerable<ArticleRange>> GetAsync()
        {
            return await _context.ArticleRanges
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<ArticleRange> GetQuery()
        {
            return _context.ArticleRanges
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<ArticleRange> GetAsync(Guid id)
        {
            ArticleRange articleRange = await _context.ArticleRanges.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return articleRange;
        }

        public ArticleRange Update(ArticleRange articleRange)
        {
            _context.Entry(articleRange).State = EntityState.Modified;
            return articleRange;
        }
    }
}
