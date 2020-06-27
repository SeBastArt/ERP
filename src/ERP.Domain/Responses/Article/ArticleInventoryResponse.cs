using ERP.Domain.Models;
using System;

namespace ERP.Domain.Responses
{
    public class ArticleInventoryResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public ArticleResponse Article { get; set; }
        public Guid ArticlePlaceId { get; set; }
        public ArticlePlaceResponse ArticlePlace { get; set; }
    }
}
