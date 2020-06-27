using System;

namespace ERP.Domain.Requests
{
    public class EditArticlePriceListInRequest
    {
        public Guid Id { get; set; }
        public decimal ScaleUnitQty { get; set; }
        public int ScaleUnitType { get; set; }
        public int UnitOrder { get; set; }
        public decimal MinOrderQty { get; set; }
        public bool IsMultipleOrderQty { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime Validto { get; set; }
        public Guid ArticleId { get; set; }
    }
}
