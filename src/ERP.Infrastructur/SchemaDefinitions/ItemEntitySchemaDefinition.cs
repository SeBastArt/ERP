using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class ItemEntitySchemaDefinition : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);

            builder.HasOne(e => e.Genre).WithMany(c => c.Items).HasForeignKey(k => k.GenreId);
            builder.HasOne(a => a.Artist).WithMany(c => c.Items).HasForeignKey(k => k.ArtistId);

            builder.Property(p => p.Price).HasConversion(
                p => $"{p.Amount}:{p.Currency}",
                p => new Price
                {
                    Amount = Convert.ToDecimal(
                        p.Split(':', StringSplitOptions.None)[0]),
                    Currency = p.Split(':', StringSplitOptions.None)[1]
                });


        }
    }
}
