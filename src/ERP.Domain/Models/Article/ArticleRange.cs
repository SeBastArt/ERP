using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class ArticleRange : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("quantity", TypeName = "decimal (38,20)")]
        public decimal Quantity { get; set; }

        [Column("netprice", TypeName = "decimal (38,20)")]
        public decimal NetPrice { get; set; }

        [Column("discount", TypeName = "decimal (38,20)")]
        public decimal Discount { get; set; }

        [Column("addition", TypeName = "decimal (38,20)")]
        public decimal Addition { get; set; }

        [Column("price", TypeName = "decimal (38,20)")]
        public decimal Price { get; set; }

        [Column("fk_article")]
        public Guid ArticleId { get; set; }

        public Article Article { get; set; }

        [Column("fk_pricelist_in")]
        public Guid ArticlePriceListInId { get; set; }

        public ArticlePriceListIn ArticlePriceListIn { get; set; }

        [Column("fk_pricelist_out")]
        public Guid ArticlePriceListOutId { get; set; }

        public ArticlePriceListOut ArticlePriceListOut { get; set; }
    }
}
