using System;

namespace ERP.Domain.Requests
{
    public class EditArticlePriceListOutRequest
    {
        public Guid Id { get; set; }
        public decimal ScaleUnitQty { get; set; }
        public int ScaleUnitType { get; set; }
        public int UnitOrder { get; set; }
        public decimal MinOrderQty { get; set; }
        public bool IsMultipleOrderQty { get; set; }
        public long Priority { get; set; }
        public DateTime ReorderTime { get; set; }
        public Guid ArticleId { get; set; }
    }
}
