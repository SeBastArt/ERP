using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IArticleRangeService
    {
        Task<IEnumerable<ArticleRangeResponse>> GetArticleRangesAsync();
        IQueryable<ArticleRangeResponse> GetArticleRangesQuery();
        Task<ArticleRangeResponse> GetArticleRangeAsync(Guid id);
        Task<ArticleRangeResponse> AddArticleRangeAsync(AddArticleRangeRequest request);
        Task<ArticleRangeResponse> EditArticleRangeAsync(EditArticleRangeRequest request);
        Task<ArticleRangeResponse> DeleteArticleRangeAsync(DeleteArticleRangeRequest request);
    }
}
