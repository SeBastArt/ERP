using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    public class FAGBinary
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("file_name", TypeName = "varchar(max)")]
        public string FileName { get; set; }

        [Column("data", TypeName = "varbinary(max)")]
        public byte[] Data { get; set; }
    }
}