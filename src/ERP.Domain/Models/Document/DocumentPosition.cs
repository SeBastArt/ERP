using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class DocumentPosition : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("position_number_text", TypeName = "varchar(max)")]
        public string PositionNumberText { get; set; }

        [Column("position_type")]
        public int PositionType { get; set; }

        [Column("article_name_extern", TypeName = "varchar(max)")]
        public string ArticleNameExtern { get; set; }

        [Column("quantitiy", TypeName = "decimal (38,20)")]
        public decimal Quantity { get; set; }

        [Column("scale_unit_qty")]
        public decimal ScaleUnitQty { get; set; }

        [Column("scale_unit_type")]
        public int ScaleUnitType { get; set; }

        [Column("scale_unit", TypeName = "varchar(max)")]
        public string ScaleUnit { get; set; }

        [Column("delivered_quantity", TypeName = "decimal (38,20)")]
        public decimal DeliveryQty { get; set; }

        [Column("is_partial_delivery")]
        public bool IsPartialDelivered { get; set; }

        [Column("price_base", TypeName = "decimal (38,20)")]
        public decimal PriceBase { get; set; }

        [Column("price_per_unit", TypeName = "decimal (38,20)")]
        public decimal PricePerUnit { get; set; }

        [Column("price_total", TypeName = "decimal (38,20)")]
        public decimal PriceTotal { get; set; }

        [Column("sales_tax_percent", TypeName = "decimal (38,20)")]
        public decimal SalesTaxPercent { get; set; }

        [Column("fk_parent")]
        public Guid? ParentId { get; set; }

        [Column("fk_parent")]
        public DocumentPosition Parent { get; set; }

        [Column("fk_document")]
        public Guid DocumentId { get; set; }

        public Document Document { get; set; }

        [Column("fk_article")]
        public Guid ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
