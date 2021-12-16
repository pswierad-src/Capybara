using Capybara.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capybara.Infrastructure.Context
{
    public class CapybaraContext : DbContext, ICapybaraContext
    {
        public CapybaraContext(DbContextOptions<CapybaraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(ConfigureBookEntity);
            modelBuilder.Entity<Author>(ConfigureAuthorEntity);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureBookEntity(EntityTypeBuilder<Book> builder)
        {
            const int decimalPrecision = 5;
            const int decimalPrecisionScale = 2;

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DateCreated).IsRequired();

            builder.Property(x => x.Title).IsRequired();

            builder.Property(x => x.Price).IsRequired().HasPrecision(decimalPrecision, decimalPrecisionScale);

            builder.HasMany(x => x.Authors);
        }

        private void ConfigureAuthorEntity(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DateCreated).IsRequired();

            builder.Property(x => x.FirstName).IsRequired();

            builder.Property(x => x.LastName).IsRequired();

            builder.HasMany(x => x.Books);
        }
    }
}
