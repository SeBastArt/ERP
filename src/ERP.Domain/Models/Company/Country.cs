using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    [Table("address_country")]
    public class Country : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("iso_3cc", TypeName = "varchar(3)")]
        public string Iso3cc { get; set; }

        [Column("iso_2cc", TypeName = "varchar(2)")]
        public string Iso2cc { get; set; }

        [Column("iso_numerical")]
        public int IsoNumerical { get; set; }

        [Column("economic_area")]
        public int EconomicArea { get; set; }

        [Column("name", TypeName = "varchar(max)")]
        public string Name { get; set; }

        [Column("address_type")]
        public int Type { get; set; }

        public ICollection<Company> Adresss { get; set; }
    }
}
