using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class CompanyPersonRelationEntitySchemaDefinition : IEntityTypeConfiguration<CompanyPersonRelation>
    {
        public void Configure(EntityTypeBuilder<CompanyPersonRelation> builder)
        {
            builder.ToTable("CompanyPersonRelation", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.HasOne(e => e.CompanyPerson).WithMany(c => c.CompanyPersonRelations).HasForeignKey(k => k.CompanyPersonId);
            builder.HasOne(e => e.Company).WithMany(c => c.CompanyPersonRelations).HasForeignKey(k => k.CompanyId);

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
        }
    }
}
