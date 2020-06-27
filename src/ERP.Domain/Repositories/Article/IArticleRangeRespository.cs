using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArticleRangeRespository : IRespository
    {
        Task<IEnumerable<ArticleRange>> GetAsync();
        IQueryable<ArticleRange> GetQuery();
        Task<ArticleRange> GetAsync(Guid id);
        ArticleRange Add(ArticleRange item);
        ArticleRange Update(ArticleRange item);
    }
}
