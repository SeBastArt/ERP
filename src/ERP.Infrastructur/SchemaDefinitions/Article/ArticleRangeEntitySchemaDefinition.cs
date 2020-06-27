using ERP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructur.SchemaDefinitions
{
    public class ArticleRangeEntitySchemaDefinition : IEntityTypeConfiguration<ArticleRange>
    {
        public void Configure(EntityTypeBuilder<ArticleRange> builder)
        {
            builder.ToTable("article_range", ERPContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id);

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.NetPrice).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(e => e.Article).WithMany(c => c.ArticleRanges).HasForeignKey(k => k.ArticleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.ArticlePriceListIn).WithMany(k => k.ArticleRanges).HasForeignKey(k => k.ArticlePriceListInId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.ArticlePriceListOut).WithMany(k => k.ArticleRanges).HasForeignKey(k => k.ArticlePriceListOutId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
