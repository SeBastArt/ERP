using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class FAGText
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("text", TypeName = "varchar(max)")]
        public string Text { get; set; }

        [Column("text_rtf", TypeName = "varbinary(max)")]
        public string TextRTF { get; set; }

        [Column("language_iso_3cc", TypeName = "varchar(3)")]
        public string Iso3cc { get; set; }

        [Column("language_iso_2cc", TypeName = "varchar(2)")]
        public string Iso2cc { get; set; }
    }
}