using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class ArticleGroupEntitySchemaDefinition : IEntityTypeConfiguration<ArticleGroup>
    {
        public void Configure(EntityTypeBuilder<ArticleGroup> builder)
        {
            builder.ToTable("article_group", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);
        }
    }
}
