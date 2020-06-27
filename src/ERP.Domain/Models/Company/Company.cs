using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Domain.Models
{
    [Table("address")]
    public class Company : BaseEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "varchar(max)")]
        public string Name { get; set; }

        [Column("addition", TypeName = "varchar(max)")]
        public string Addition { get; set; }

        [Column("addition2", TypeName = "varchar(max)")]
        public string Addition2 { get; set; }

        [Column("street", TypeName = "varchar(max)")]
        public string Street { get; set; }

        [Column("postcode", TypeName = "varchar(max)")]
        public string PostCode { get; set; }

        [Column("city", TypeName = "varchar(max)")]
        public string City { get; set; }

        [Column("email", TypeName = "varchar(max)")]
        public string Email { get; set; }

        [Column("phone", TypeName = "varchar(max)")]
        public string Phone { get; set; }

        [Column("fax", TypeName = "varchar(max)")]
        public string Fax { get; set; }

        [Column("vat_id_no", TypeName = "varchar(max)")]
        public string VatId { get; set; }

        [Column("timezone", TypeName = "varchar(max)")]
        public string TimeZone { get; set; }

        [Column("fk_parent_address")]
        public Guid? ParentId { get; set; }

        //[ForeignKey("fk_parent_address")]
        public Company Parent { get; set; }

        [Column("fk_address_country")]
        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        [Column("fk_logo")]
        public Guid? LogoId { get; set; }

        public FAGBinary Logo { get; set; }

        [Column("fk_address_company_type")]
        public Guid CompanyTypeId { get; set; }

        public CompanyType CompanyType { get; set; }

        [Column("addresspersonrelations")]
        public ICollection<CompanyPersonRelation> CompanyPersonRelations { get; }// = new List<CompanyPersonRelation>();
    }
}
