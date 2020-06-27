using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class ArticlePlaceEntitySchemaDefinition : IEntityTypeConfiguration<ArticlePlace>
    {
        public void Configure(EntityTypeBuilder<ArticlePlace> builder)
        {
            builder.ToTable("article_places", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);
        }
    }
}
