using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class PersonEntitySchemaDefinition : IEntityTypeConfiguration<CompanyPersonRelation>
    {
        public void Configure(EntityTypeBuilder<CompanyPersonRelation> builder)
        {
            builder.ToTable("CompanyPerson", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.CompanyPersonId);
            builder.Property(k => k.CompanyPersonId);

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();

            // builder.HasOne(e => e.Picture);
        }
    }
}
