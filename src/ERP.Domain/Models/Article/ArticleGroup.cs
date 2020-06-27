using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class ArticleGroup : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
