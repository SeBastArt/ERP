using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArticleRespository : IRespository
    {
        Task<IEnumerable<Article>> GetAsync();
        IQueryable<Article> GetQuery();
        Task<Article> GetAsync(Guid id);
        Article Add(Article item);
        Article Update(Article item);
    }
}
