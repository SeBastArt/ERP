using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    internal class DocumentPositionEntitySchemaDefinition : IEntityTypeConfiguration<DocumentPosition>
    {
        public void Configure(EntityTypeBuilder<DocumentPosition> builder)
        {
            builder.ToTable("document_position", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.Property(c => c.PositionNumberText).IsRequired();
        }
    }
}