using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArticleInventoryRespository : IRespository
    {
        Task<IEnumerable<ArticleInventory>> GetAsync();
        IQueryable<ArticleInventory> GetQuery();
        Task<ArticleInventory> GetAsync(Guid id);
        ArticleInventory Add(ArticleInventory item);
        ArticleInventory Update(ArticleInventory item);
    }
}
