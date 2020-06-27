using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IArticleGroupMapper
    {
        ArticleGroup Map(AddArticleGroupRequest request);
        ArticleGroup Map(EditArticleGroupRequest request);
        ArticleGroupResponse Map(ArticleGroup item);
    }
}
