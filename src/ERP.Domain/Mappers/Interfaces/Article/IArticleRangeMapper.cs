using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IArticleRangeMapper
    {
        ArticleRange Map(AddArticleRangeRequest request);
        ArticleRange Map(EditArticleRangeRequest request);
        ArticleRangeResponse Map(ArticleRange item);
    }
}
