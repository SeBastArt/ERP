using System;

namespace ERP.Domain.Requests
{
    public class AddDocumentPositionRequest
    {
        public string PositionNumberText { get; set; }
        public int PositionType { get; set; }
        public string ArticleNameExtern { get; set; }
        public decimal Quantity { get; set; }
        public decimal ScaleUnitQty { get; set; }
        public int ScaleUnitType { get; set; }
        public string ScaleUnit { get; set; }
        public decimal DeliveryQty { get; set; }
        public bool IsPartialDelivered { get; set; }
        public decimal PriceBase { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal PriceTotal { get; set; }
        public decimal SalesTaxPercent { get; set; }
        public Guid ParentId { get; set; }
        public Guid DocumentId { get; set; }
        public Guid ArticleId { get; set; }
    }
}
