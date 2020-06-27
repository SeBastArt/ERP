using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    internal class ArticleTypeEntitySchemaDefinition : IEntityTypeConfiguration<ArticleType>
    {
        public void Configure(EntityTypeBuilder<ArticleType> builder)
        {
            builder.ToTable("article_type", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.NatureType).IsRequired();
        }
    }
}
