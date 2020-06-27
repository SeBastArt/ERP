using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    internal class DocumentEntitySchemaDefinition : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("document", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.HasOne(e => e.DocumentPerson);
            builder.HasOne(e => e.DocumentCompany);
            builder.HasOne(e => e.DeliveryPerson);
            builder.HasOne(e => e.DeliveryCompany);
            builder.HasOne(e => e.InvoicePerson);
            builder.HasOne(e => e.InvoiceCompany);
        }
    }
}
