using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    [Table("address_person")]
    public class Person : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("lastname", TypeName = "varchar(max)")]
        public string LastName { get; set; }

        [Column("firstname", TypeName = "varchar(max)")]
        public string FirstName { get; set; }

        [Column("sex", TypeName = "varchar(max)")]
        public string Sex { get; set; }

        [Column("department", TypeName = "varchar(max)")]
        public string Department { get; set; }

        [Column("phone_office", TypeName = "varchar(max)")]
        public string PhoneOffice { get; set; }

        [Column("phone_private", TypeName = "varchar(max)")]
        public string PhonePrivate { get; set; }

        [Column("email", TypeName = "varchar(max)")]
        public string Email { get; set; }

        [Column("fk_picture")]
        public Guid? PictureId { get; set; }

        [Column(TypeName = "varchar(max)")]
        public FAGBinary Picture { get; set; }

        public ICollection<CompanyPersonRelation> CompanyPersonRelations { get; } = new List<CompanyPersonRelation>();

    }
}
