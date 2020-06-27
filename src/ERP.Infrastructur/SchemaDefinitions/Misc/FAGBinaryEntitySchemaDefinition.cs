using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    internal class FAGBinaryEntitySchemaDefinition : IEntityTypeConfiguration<FAGBinary>
    {
        public void Configure(EntityTypeBuilder<FAGBinary> builder)
        {
            builder.ToTable("fag_binary", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);
        }
    }
}
