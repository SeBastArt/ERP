using System;

namespace ERP.Domain.Requests
{
    public class EditArticleRangeRequest
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Addition { get; set; }
        public decimal Price { get; set; }
        public Guid ArticleId {get; set; }
        public Guid ArticlePriceListInId { get; set; }
        public Guid ArticlePriceListOutId { get; set; }
    }
}
