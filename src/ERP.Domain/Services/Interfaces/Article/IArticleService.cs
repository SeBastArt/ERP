using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleResponse>> GetArticlesAsync();
        IQueryable<ArticleResponse> GetArticlesQuery();
        Task<ArticleResponse> GetArticleAsync(Guid id);
        Task<ArticleResponse> AddArticleAsync(AddArticleRequest request);
        Task<ArticleResponse> EditArticleAsync(EditArticleRequest request);
        Task<ArticleResponse> DeleteArticleAsync(DeleteArticleRequest request);
    }
}
