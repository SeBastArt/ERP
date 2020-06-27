using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class Article : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("material_type")]
        public int MaterialType { get; set; }

        [Column("is_archived")]
        public bool IsArchived { get; set; }

        [Column("is_discontinued")]
        public bool IsDiscontinued { get; set; }

        [Column("is_batch")]
        public bool IsBatch { get; set; }

        [Column("is_multistock")]
        public bool IsMultistock { get; set; }

        [Column("is_provision_enabled")]
        public bool IsProvisionEnabled { get; set; }

        [Column("is_discount_enabled")]
        public bool IsDiscountEnabled { get; set; }

        [Column("is_disposition")]
        public bool IsDisposition { get; set; }

        [Column("is_casting")]
        public bool IsCasting { get; set; }

        [Column("scale_unit_qty")]
        public decimal ScaleUnitQty { get; set; }

        [Column("scale_unit_type")]
        public int ScaleUnitType { get; set; }

        [Column("unit_stock")]
        public int UnitStock { get; set; }

        [Column("unit_stock_in")]
        public int UnitStockIn { get; set; }

        [Column("unit_stock_out")]
        public int UnitStockOut { get; set; }

        [Column("dim_area")]
        public decimal DimArea { get; set; }

        [Column("dim_length")]
        public decimal DimLength { get; set; }

        [Column("dim_2")]
        public decimal Dim2 { get; set; }

        [Column("dim_3")]
        public decimal Dim3 { get; set; }

        [Column("dim_4")]
        public decimal Dim4 { get; set; }

        [Column("specific_weight", TypeName = "decimal (38,20)")]
        public decimal SpecificWeight { get; set; }

        [Column("item_number")]
        public string ItemNumber { get; set; }

        [Column("drawing_number")]
        public string DrawingNumber { get; set; }

        [Column("din_norm1")]
        public string DinNorm1 { get; set; }

        [Column("din_norm2")]
        public string DinNorm2 { get; set; }

        [Column("fk_group")]
        public Guid ArticleGroupId { get; set; }

        public ArticleGroup ArticleGroup { get; set; }

        [Column("fk_type")]
        public Guid ArticleTypeId { get; set; }

        public ArticleType ArticleType { get; set; }

        public ICollection<ArticleInventory> ArticleInventories { get; set; } = new List<ArticleInventory>();

        public ICollection<ArticleRange> ArticleRanges { get; set; } = new List<ArticleRange>();

        public ICollection<FAGBinary> Pictures { get; set; } = new List<FAGBinary>();
    }
}
