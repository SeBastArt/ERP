using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArticlePlaceRespository : IRespository
    {
        Task<IEnumerable<ArticlePlace>> GetAsync();
        IQueryable<ArticlePlace> GetQuery();
        Task<ArticlePlace> GetAsync(Guid id);
        ArticlePlace Add(ArticlePlace item);
        ArticlePlace Update(ArticlePlace item);
    }
}
