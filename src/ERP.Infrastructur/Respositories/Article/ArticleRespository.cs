using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArticleRespository : IArticleRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticleRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Article Add(Article article)
        {
            return _context.Articles.Add(article).Entity;
        }

        public async Task<IEnumerable<Article>> GetAsync()
        {
            return await _context.Articles
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Article> GetQuery()
        {
            return _context.Articles
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<Article> GetAsync(Guid id)
        {
            Article article = await _context.Articles.AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.ArticleGroup)
                .Include(x => x.ArticleType)
                .Include(x => x.ArticleInventories)
                .Include(x => x.ArticleRanges)
                .Include(x => x.Pictures)
                .FirstOrDefaultAsync();
            return article;
        }

        public Article Update(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            return article;
        }
    }
}
