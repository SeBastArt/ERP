using ERP.Domain.Models;
using ERP.Domain.Respositories;
using ERP.Infrastructur.SchemaDefinitions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Infrastructur
{
    public class ERPContext : IdentityDbContext<User>, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "erp";
        public DbSet<Item> Items { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genres { get; set; }

        //Company
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<CompanyPersonRelation> CompanyPersonRelations { get; set; }

        //Articles
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<ArticleInventory> ArticleInventories { get; set; }
        public DbSet<ArticlePlace> ArticlePlaces { get; set; }
        public DbSet<ArticleRange> ArticleRanges { get; set; }
        public DbSet<ArticleType> ArticleTypes { get; set; }

        //Article PriceLists
        public DbSet<ArticlePriceListIn> ArticlePriceListsIn { get; set; }
        public DbSet<ArticlePriceListOut> ArticlePriceListsOut { get; set; }

        //Documents
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentPosition> DocumentPositions { get; set; }

        //Misc
        public DbSet<FAGBinary> FAGBinaries { get; set; }
        public DbSet<FAGText> FAGTexts { get; set; }

        public ERPContext(DbContextOptions<ERPContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new ItemEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new GenreEntitySchemaConfiguration());
            _ = modelBuilder.ApplyConfiguration(new ArtistEntitySchemaConfiguration());

            _ = modelBuilder.ApplyConfiguration(new CompanyTypeEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new CountryEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new CompanyEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new PersonEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new CompanyPersonRelationEntitySchemaDefinition());

            _ = modelBuilder.ApplyConfiguration(new ArticleEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new ArticleGroupEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new ArticleInventoryEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new ArticlePlaceEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new ArticleRangeEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new ArticleTypeEntitySchemaDefinition());

            _ = modelBuilder.ApplyConfiguration(new ArticlePriceListInEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new ArticlePriceListOutEntitySchemaDefinition());

            _ = modelBuilder.ApplyConfiguration(new DocumentEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new DocumentPositionEntitySchemaDefinition());

            _ = modelBuilder.ApplyConfiguration(new FAGTextEntitySchemaDefinition());
            _ = modelBuilder.ApplyConfiguration(new FAGBinaryEntitySchemaDefinition());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
