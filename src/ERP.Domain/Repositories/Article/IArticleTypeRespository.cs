using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArticleTypeRespository : IRespository
    {
        Task<IEnumerable<ArticleType>> GetAsync();
        IQueryable<ArticleType> GetQuery();
        Task<ArticleType> GetAsync(Guid id);
        ArticleType Add(ArticleType item);
        ArticleType Update(ArticleType item);
    }
}
