using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class GenreEntitySchemaConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.GenreId);
            builder.Property(p => p.GenreId);
            builder.Property(p => p.GenreDescription)
            .IsRequired()
            .HasMaxLength(1000);
        }
    }
}
