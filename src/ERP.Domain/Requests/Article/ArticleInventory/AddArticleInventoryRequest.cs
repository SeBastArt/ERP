using System;

namespace ERP.Domain.Requests
{
    public class AddArticleInventoryRequest
    {
        public Guid ArticleInventoryId { get; set; }
        public Guid ArticleId { get; set; }
        public Guid ArticlePlaceId { get; set; }
    }
}
