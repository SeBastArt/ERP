using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    [Table("address_company_type")]
    public class CompanyType : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "varchar(max)")]
        public string Name { get; set; }

        [Column("type")]
        public int Type { get; set; }

        public ICollection<Company> Companyes { get; set; }
    }
}
