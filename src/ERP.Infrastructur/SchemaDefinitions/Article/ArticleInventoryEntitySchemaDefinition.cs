using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class ArticleInventoryEntitySchemaDefinition : IEntityTypeConfiguration<ArticleInventory>
    {
        public void Configure(EntityTypeBuilder<ArticleInventory> builder)
        {
            builder.ToTable("article_inventory", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.HasOne(e => e.Article).WithMany(c => c.ArticleInventories).HasForeignKey(k => k.Id);
            builder.HasOne(e => e.ArticlePlace);
        }
    }
}
