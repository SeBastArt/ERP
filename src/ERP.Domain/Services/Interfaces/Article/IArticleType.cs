using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IArticleTypeService
    {
        Task<IEnumerable<ArticleTypeResponse>> GetArticleTypesAsync();
        IQueryable<ArticleTypeResponse> GetArticleTypesQuery();
        Task<ArticleTypeResponse> GetArticleTypeAsync(Guid id);
        Task<ArticleTypeResponse> AddArticleTypeAsync(AddArticleTypeRequest request);
        Task<ArticleTypeResponse> EditArticleTypeAsync(EditArticleTypeRequest request);
        Task<ArticleTypeResponse> DeleteArticleTypeAsync(DeleteArticleTypeRequest request);
    }
}
