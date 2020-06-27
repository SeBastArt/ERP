using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class CompanyTypeEntitySchemaDefinition : IEntityTypeConfiguration<CompanyType>
    {
        public void Configure(EntityTypeBuilder<CompanyType> builder)
        {
            builder.ToTable("CompanyCompanyType", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Type).IsRequired();

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
        }
    }
}
