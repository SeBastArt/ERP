using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class ArticlePlace : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("reserved_qty", TypeName = "decimal (38,20)")]
        public decimal ReservedQty { get; set; }

        [Column("minimum_qty", TypeName = "decimal (38,20)")]
        public decimal MinimumQty { get; set; }

        [Column("opo_qty", TypeName = "decimal (38,20)")]
        public decimal OpoQty { get; set; }

        [Column("fk_address")]
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
