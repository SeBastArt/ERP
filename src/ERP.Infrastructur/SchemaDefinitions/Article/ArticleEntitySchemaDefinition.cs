using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class ArticleEntitySchemaDefinition : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("article", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.MaterialType).IsRequired();
            builder.Property(x => x.IsArchived).IsRequired();
            builder.Property(x => x.IsDiscontinued).IsRequired();
            builder.Property(x => x.IsBatch).IsRequired();
            builder.Property(x => x.IsMultistock).IsRequired();
            builder.Property(x => x.IsProvisionEnabled).IsRequired();
            builder.Property(x => x.IsDiscountEnabled).IsRequired();
            builder.Property(x => x.IsDisposition).IsRequired();
            builder.Property(x => x.IsCasting).IsRequired();

            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();

            builder.HasOne(e => e.ArticleType);
            builder.HasOne(e => e.ArticleGroup);
        }
    }
}
