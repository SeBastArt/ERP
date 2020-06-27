using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IArticleInventoryService
    {
        Task<IEnumerable<ArticleInventoryResponse>> GetArticleInventoriesAsync();
        IQueryable<ArticleInventoryResponse> GetArticleInventoriesQuery();
        Task<ArticleInventoryResponse> GetArticleInventoryAsync(Guid id);
        Task<ArticleInventoryResponse> AddArticleInventoryAsync(AddArticleInventoryRequest request);
        Task<ArticleInventoryResponse> EditArticleInventoryAsync(EditArticleInventoryRequest request);
        Task<ArticleInventoryResponse> DeleteArticleInventoryAsync(DeleteArticleInventoryRequest request);
    }
}
