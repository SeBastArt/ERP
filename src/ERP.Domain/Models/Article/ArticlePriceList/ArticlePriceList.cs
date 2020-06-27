using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class ArticlePriceList : BaseEntity
    {
        [Column("scale_unit_qty")]
        public decimal ScaleUnitQty { get; set; }

        [Column("scale_unit_type")]
        public int ScaleUnitType { get; set; }

        [Column("unit_order")]
        public int UnitOrder { get; set; }

        [Column("min_order_qty", TypeName = "decimal (38,20)")]
        public decimal MinOrderQty { get; set; }

        [Column("is_multiply_order_qty")]
        public bool IsMultipleOrderQty { get; set; }

    }
}
