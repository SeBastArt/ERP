using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class CompanyEntitySchemaDefinition : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.CountryId).IsRequired();
            builder.Property(x => x.CompanyTypeId).IsRequired();

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();

            builder.HasOne(e => e.Country).WithMany(c => c.Adresss).HasForeignKey(k => k.CountryId);
            builder.HasOne(e => e.Logo);
            builder.HasOne(e => e.CompanyType).WithMany(c => c.Companyes).HasForeignKey(k => k.CompanyTypeId);
        
      

        }
    }
}


//builder.ToTable("Items", ERPContext.DEFAULT_SCHEMA);
//            builder.HasKey(k => k.Id);

//            builder.Property(x => x.Name).IsRequired();

//builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);

//builder.HasOne(e => e.Genre).WithMany(c => c.Items).HasForeignKey(k => k.GenreId);
//builder.HasOne(a => a.Artist).WithMany(c => c.Items).HasForeignKey(k => k.ArtistId);

//builder.Property(p => p.Price).HasConversion(
//    p => $"{p.Amount}:{p.Currency}",
//    p => new Price
//                {
//                    Amount = Convert.ToDecimal(
//                        p.Split(':', StringSplitOptions.None)[0]),
//                    Currency = p.Split(':', StringSplitOptions.None)[1]
//                });


