using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    internal class ArticlePriceListOutEntitySchemaDefinition : IEntityTypeConfiguration<ArticlePriceListOut>
    {
        public void Configure(EntityTypeBuilder<ArticlePriceListOut> builder)
        {
            builder.ToTable("article_pricelist_out", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);
        }
    }
}
