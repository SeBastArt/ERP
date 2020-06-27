using System;

namespace ERP.Domain.Requests
{
    public class EditArticleInventoryRequest
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public Guid ArticlePlaceId { get; set; }
    }
}
