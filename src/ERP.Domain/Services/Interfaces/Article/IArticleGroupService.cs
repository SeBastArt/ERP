using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IArticleGroupService
    {
        Task<IEnumerable<ArticleGroupResponse>> GetArticleGroupsAsync();
        IQueryable<ArticleGroupResponse> GetArticleGroupsQuery();
        Task<ArticleGroupResponse> GetArticleGroupAsync(Guid id);
        Task<ArticleGroupResponse> AddArticleGroupAsync(AddArticleGroupRequest request);
        Task<ArticleGroupResponse> EditArticleGroupAsync(EditArticleGroupRequest request);
        Task<ArticleGroupResponse> DeleteArticleGroupAsync(DeleteArticleGroupRequest request);
    }
}
