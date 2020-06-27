using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IArticleTypeMapper
    {
        ArticleType Map(AddArticleTypeRequest request);
        ArticleType Map(EditArticleTypeRequest request);
        ArticleTypeResponse Map(ArticleType item);
    }
}
