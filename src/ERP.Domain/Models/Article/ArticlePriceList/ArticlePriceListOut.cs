using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ERP.Domain.Models
{
    public class ArticlePriceListOut : ArticlePriceList
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("priority")]
        public long Priority { get; set; }

        [Column("reordertime")]
        public DateTime ReorderTime { get; set; }

        [JsonIgnore]
        [Column("fk_article")]
        public Guid ArticleId { get; set; }

        public Article Article { get; set; }

        public ICollection<ArticleRange> ArticleRanges { get; set; }// = new List<ArticleRange>();
    }
}
