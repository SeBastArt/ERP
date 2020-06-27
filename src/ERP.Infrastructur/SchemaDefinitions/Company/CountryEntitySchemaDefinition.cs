using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class CountryEntitySchemaDefinition : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("CompanyCountry", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.Property(x => x.Iso3cc).IsRequired().HasMaxLength(3);
            builder.Property(x => x.Iso2cc).IsRequired().HasMaxLength(2);
            builder.Property(x => x.IsoNumerical).IsRequired();
            builder.Property(x => x.EconomicArea).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
        }
    }
}
