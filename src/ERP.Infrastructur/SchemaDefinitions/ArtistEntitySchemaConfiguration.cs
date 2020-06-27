using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class ArtistEntitySchemaConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artists", ERPContext.DEFAULT_SCHEMA);

            builder.HasKey(x => x.ArtistId);

            builder.Property(p => p.ArtistId);
            builder.Property(p => p.ArtistName)
            .IsRequired()
            .HasMaxLength(200);
        }
    }
}
