using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IArticleInventoryMapper
    {
        ArticleInventory Map(AddArticleInventoryRequest request);
        ArticleInventory Map(EditArticleInventoryRequest request);
        ArticleInventoryResponse Map(ArticleInventory item);
    }
}
