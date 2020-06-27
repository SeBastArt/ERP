using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class ArticleGroupRespository : IArticleGroupRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ArticleGroupRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ArticleGroup Add(ArticleGroup articleGroup)
        {
            return _context.ArticleGroups.Add(articleGroup).Entity;
        }

        public async Task<IEnumerable<ArticleGroup>> GetAsync()
        {
            return await _context.ArticleGroups
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<ArticleGroup> GetQuery()
        {
            return _context.ArticleGroups
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<ArticleGroup> GetAsync(Guid id)
        {
            ArticleGroup articleGroup = await _context.ArticleGroups.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return articleGroup;
        }

        public ArticleGroup Update(ArticleGroup articleGroup)
        {
            _context.Entry(articleGroup).State = EntityState.Modified;
            return articleGroup;
        }
    }
}
