using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArticleGroupRespository : IRespository
    {
        Task<IEnumerable<ArticleGroup>> GetAsync();
        IQueryable<ArticleGroup> GetQuery();
        Task<ArticleGroup> GetAsync(Guid id);
        ArticleGroup Add(ArticleGroup item);
        ArticleGroup Update(ArticleGroup item);
    }
}
