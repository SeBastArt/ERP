using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IArticlePriceListInService
    {
        Task<IEnumerable<ArticlePriceListInResponse>> GetArticlePriceListsInAsync();
        IQueryable<ArticlePriceListInResponse> GetArticlePriceListsInQuery();
        Task<ArticlePriceListInResponse> GetArticlePriceListInAsync(Guid id);
        Task<ArticlePriceListInResponse> AddArticlePriceListInAsync(AddArticlePriceListInRequest request);
        Task<ArticlePriceListInResponse> EditArticlePriceListInAsync(EditArticlePriceListInRequest request);
        Task<ArticlePriceListInResponse> DeleteArticlePriceListInAsync(DeleteArticlePriceListInRequest request);
    }
}
