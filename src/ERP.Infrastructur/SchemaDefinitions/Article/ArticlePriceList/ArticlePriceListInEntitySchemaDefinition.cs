using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    internal class ArticlePriceListInEntitySchemaDefinition : IEntityTypeConfiguration<ArticlePriceListIn>
    {
        public void Configure(EntityTypeBuilder<ArticlePriceListIn> builder)
        {
            builder.ToTable("article_pricelist_in", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);
        }
    }
}
