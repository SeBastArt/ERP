using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IArticlePriceListOutService
    {
        Task<IEnumerable<ArticlePriceListOutResponse>> GetArticlePriceListsOutAsync();
        IQueryable<ArticlePriceListOutResponse> GetArticlePriceListsOutQuery();
        Task<ArticlePriceListOutResponse> GetArticlePriceListOutAsync(Guid id);
        Task<ArticlePriceListOutResponse> AddArticlePriceListOutAsync(AddArticlePriceListOutRequest request);
        Task<ArticlePriceListOutResponse> EditArticlePriceListOutAsync(EditArticlePriceListOutRequest request);
        Task<ArticlePriceListOutResponse> DeleteArticlePriceListOutAsync(DeleteArticlePriceListOutRequest request);
    }
}
