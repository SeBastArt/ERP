using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IArticleMapper
    {
        Article Map(AddArticleRequest request);
        Article Map(EditArticleRequest request);
        ArticleResponse Map(Article item);
    }
}
