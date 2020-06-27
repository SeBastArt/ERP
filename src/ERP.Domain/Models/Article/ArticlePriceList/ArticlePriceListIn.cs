using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ERP.Domain.Models
{
    public class ArticlePriceListIn : ArticlePriceList
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("valid_from")]
        public DateTime ValidFrom { get; set; }

        [Column("valid_to")]
        public DateTime Validto { get; set; }

        [JsonIgnore]
        [Column("fk_article")]
        public Guid ArticleId { get; set; }

        public Article Article { get; set; }

        public ICollection<ArticleRange> ArticleRanges { get; set; }// = new List<ArticleRange>();
    }
}
