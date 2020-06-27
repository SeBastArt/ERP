using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    [Table("article_inventory")]
    public class ArticleInventory : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("fk_article")]
        public Guid ArticleId { get; set; }

        public Article Article { get; set; }

        [Column("fk_place")]
        public Guid ArticlePlaceId { get; set; }

        public ArticlePlace ArticlePlace { get; set; }
    }
}
