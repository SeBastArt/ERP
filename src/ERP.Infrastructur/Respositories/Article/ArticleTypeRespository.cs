using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArticleTypeRespository : IArticleTypeRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticleTypeRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArticleType Add(ArticleType articleType)
        {
            return _context.ArticleTypes.Add(articleType).Entity;
        }

        public async Task<IEnumerable<ArticleType>> GetAsync()
        {
            return await _context.ArticleTypes
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<ArticleType> GetQuery()
        {
            return _context.ArticleTypes
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<ArticleType> GetAsync(Guid id)
        {
            ArticleType articleType = await _context.ArticleTypes.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return articleType;
        }

        public ArticleType Update(ArticleType articleType)
        {
            _context.Entry(articleType).State = EntityState.Modified;
            return articleType;
        }
    }
}
