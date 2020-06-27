using ERP.Domain.Models;
using System;

namespace ERP.Domain.Responses
{
    public class ArticleRangeResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Addition { get; set; }
        public decimal Price { get; set; }
        public Guid ArticleId { get; set; }
        public ArticleResponse Article { get; set; }
        public Guid ArticlePriceListInId { get; set; }
        public ArticlePriceListInResponse ArticlePriceListIn { get; set; }
        public Guid ArticlePriceListOutId { get; set; }
        public ArticlePriceListOutResponse ArticlePriceListOut { get; set; }
    }
}
