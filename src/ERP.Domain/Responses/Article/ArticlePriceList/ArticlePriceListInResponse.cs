using ERP.Domain.Models;
using System;
using System.Collections.Generic;

namespace ERP.Domain.Responses
{
    public class ArticlePriceListInResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime Validto { get; set; }
        public decimal ScaleUnitQty { get; set; }
        public int ScaleUnitType { get; set; }
        public int UnitOrder { get; set; }
        public decimal MinOrderQty { get; set; }
        public bool IsMultipleOrderQty { get; set; }
        public Guid ArticleId { get; set; }
        public ArticleResponse Article { get; set; }
        public ICollection<ArticleRangeResponse> ArticleRanges { get; set; }
    }
}
