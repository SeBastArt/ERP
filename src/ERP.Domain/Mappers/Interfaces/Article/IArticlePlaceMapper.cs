using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IArticlePlaceMapper
    {
        ArticlePlace Map(AddArticlePlaceRequest request);
        ArticlePlace Map(EditArticlePlaceRequest request);
        ArticlePlaceResponse Map(ArticlePlace item);
    }
}
