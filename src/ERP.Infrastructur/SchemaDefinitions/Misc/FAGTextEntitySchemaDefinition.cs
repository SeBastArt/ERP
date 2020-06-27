using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    internal class FAGTextEntitySchemaDefinition : IEntityTypeConfiguration<FAGText>
    {
        public void Configure(EntityTypeBuilder<FAGText> builder)
        {
            builder.ToTable("fag_text", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);
        }
    }
}
