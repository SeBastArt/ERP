using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    [Table("address_person_relation")]
    public class CompanyPersonRelation : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("fk_address")]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        [Column("fk_person")]
        public Guid CompanyPersonId { get; set; }
        public Person CompanyPerson { get; set; }
    }
}
