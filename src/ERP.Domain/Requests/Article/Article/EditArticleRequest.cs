using System;

namespace ERP.Domain.Requests
{
    public class EditArticleRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MaterialType { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDiscontinued { get; set; }
        public bool IsBatch { get; set; }
        public bool IsMultistock { get; set; }
        public bool IsProvisionEnabled { get; set; }
        public bool IsDiscountEnabled { get; set; }
        public bool IsDisposition { get; set; }
        public bool IsCasting { get; set; }
        public decimal ScaleUnitQty { get; set; }
        public int ScaleUnitType { get; set; }
        public int UnitStock { get; set; }
        public int UnitStockIn { get; set; }
        public int UnitStockOut { get; set; }
        public decimal DimArea { get; set; }
        public decimal DimLength { get; set; }
        public decimal Dim2 { get; set; }
        public decimal Dim3 { get; set; }
        public decimal Dim4 { get; set; }
        public decimal SpecificWeight { get; set; }
        public string ItemNumber { get; set; }
        public string DrawingNumber { get; set; }
        public string DinNorm1 { get; set; }
        public string DinNorm2 { get; set; }
        public Guid ArticleGroupId { get; set; }
        public Guid ArticleTypeId { get; set; }
    }
}
