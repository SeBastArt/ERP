using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArticlePriceListOutRespository : IRespository
    {
        Task<IEnumerable<ArticlePriceListOut>> GetAsync();
        IQueryable<ArticlePriceListOut> GetQuery();
        Task<ArticlePriceListOut> GetAsync(Guid id);
        ArticlePriceListOut Add(ArticlePriceListOut item);
        ArticlePriceListOut Update(ArticlePriceListOut item);
    }
}
