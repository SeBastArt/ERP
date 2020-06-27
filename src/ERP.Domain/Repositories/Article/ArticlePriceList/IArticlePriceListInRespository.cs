using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArticlePriceListInRespository : IRespository
    {
        Task<IEnumerable<ArticlePriceListIn>> GetAsync();
        IQueryable<ArticlePriceListIn> GetQuery();
        Task<ArticlePriceListIn> GetAsync(Guid id);
        ArticlePriceListIn Add(ArticlePriceListIn item);
        ArticlePriceListIn Update(ArticlePriceListIn item);
    }
}
