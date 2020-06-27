using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArticlePlaceRespository : IArticlePlaceRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticlePlaceRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArticlePlace Add(ArticlePlace articlePlace)
        {
            return _context.ArticlePlaces.Add(articlePlace).Entity;
        }

        public async Task<IEnumerable<ArticlePlace>> GetAsync()
        {
            return await _context.ArticlePlaces
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<ArticlePlace> GetQuery()
        {
            return _context.ArticlePlaces
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<ArticlePlace> GetAsync(Guid id)
        {
            ArticlePlace articlePlace = await _context.ArticlePlaces.AsNoTracking().Where(x => x.Id == id).Include(x => x.Company).FirstOrDefaultAsync();
            return articlePlace;
        }

        public ArticlePlace Update(ArticlePlace articlePlace)
        {
            _context.Entry(articlePlace).State = EntityState.Modified;
            return articlePlace;
        }
    }
}
