using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using UniqueIdentifiersBenchmark.Data.Entity;

namespace UniqueIdentifiersBenchmark.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AuthorAsPrimaryKeyInt> AuthorsAsPrimaryKeyInt { get; set; }
        public DbSet<BookAsPrimaryKeyInt> BooksAsPrimaryKeyInt { get; set; }
        public DbSet<AuthorAsPrimaryKeyCuid> AuthorsAsPrimaryKeyCuid { get; set; }
        public DbSet<BookAsPrimaryKeyCuid> BooksAsPrimaryKeyCuid { get; set; }
        public DbSet<AuthorAsPrimaryKeyGuid> AuthorsAsPrimaryKeyGuid { get; set; }
        public DbSet<BookAsPrimaryKeyGuid> BooksAsPrimaryKeyGuid { get; set; }
        public DbSet<AuthorAsPrimaryKeyNanoid> AuthorsAsPrimaryKeyNanoid { get; set; }
        public DbSet<BookAsPrimaryKeyNanoid> BooksAsPrimaryKeyNanoid { get; set; }
        public DbSet<AuthorAsPrimaryKeyUlid> AuthorsAsPrimaryKeyUlid { get; set; }
        public DbSet<BookAsPrimaryKeyUlid> BooksAsPrimaryKeyUlid { get; set; }

        public DbSet<AuthorWithCuidReferenceId> AuthorsWithCuidReferenceId { get; set; }
        public DbSet<BookWithCuidReferenceId> BooksWithCuidReferenceId { get; set; }
        public DbSet<AuthorWithGuidReferenceId> AuthorsWithGuidReferenceId { get; set; }
        public DbSet<BookWithGuidReferenceId> BooksWithGuidReferenceId { get; set; }
        public DbSet<AuthorWithNanoidReferenceId> AuthorsWithNanoidReferenceId { get; set; }
        public DbSet<BookWithNanoidReferenceId> BooksWithNanoidReferenceId { get; set; }
        public DbSet<AuthorWithUlidReferenceId> AuthorsWithUlidReferenceId { get; set; }
        public DbSet<BookWithUlidReferenceId> BooksWithUlidReferenceId { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureAuthorBookRelationship<AuthorAsPrimaryKeyInt, BookAsPrimaryKeyInt, int>(modelBuilder);
            ConfigureAuthorBookRelationship<AuthorAsPrimaryKeyCuid, BookAsPrimaryKeyCuid, string>(modelBuilder);
            ConfigureAuthorBookRelationship<AuthorAsPrimaryKeyGuid, BookAsPrimaryKeyGuid, Guid>(modelBuilder);
            ConfigureAuthorBookRelationship<AuthorAsPrimaryKeyNanoid, BookAsPrimaryKeyNanoid, string>(modelBuilder);
            ConfigureAuthorBookRelationship<AuthorAsPrimaryKeyUlid, BookAsPrimaryKeyUlid, Ulid>(modelBuilder);

            ConfigureReferencedAuthorBookRelationship<AuthorWithCuidReferenceId, BookWithCuidReferenceId, string>(modelBuilder);
            ConfigureReferencedAuthorBookRelationship<AuthorWithGuidReferenceId, BookWithGuidReferenceId, Guid>(modelBuilder);
            ConfigureReferencedAuthorBookRelationship<AuthorWithNanoidReferenceId, BookWithNanoidReferenceId, string>(modelBuilder);
            ConfigureReferencedAuthorBookRelationship<AuthorWithUlidReferenceId, BookWithUlidReferenceId, Ulid>(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureAuthorBookRelationship<TAuthor, TBook, TKey>(ModelBuilder modelBuilder)
            where TAuthor : AuthorBase<TKey>
            where TBook : BookBase<TKey>
        {
            modelBuilder.Entity<TBook>(e =>
            {
                if (e.Metadata.ClrType.GetProperty("Id").PropertyType == typeof(Ulid))
                {
                    e.Property(e => e.Id).HasConversion(new UlidToStringConverter());
                }
            });

            modelBuilder.Entity<TBook>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<TBook>()
                .HasIndex(b => b.Id)
                .IsUnique();

            modelBuilder.Entity<TBook>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<TAuthor>(e =>
            {
                if (e.Metadata.ClrType.GetProperty("Id").PropertyType == typeof(Ulid))
                {
                    e.Property(e => e.Id).HasConversion(new UlidToStringConverter());
                }
            });

            modelBuilder.Entity<TAuthor>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<TAuthor>()
                .HasIndex(a => a.Id)
                .IsUnique();

            modelBuilder.Entity<TAuthor>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<TAuthor>()
                .HasMany(a => (ICollection<TBook>)a.Books)
                .WithOne(b => (TAuthor)b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private static void ConfigureReferencedAuthorBookRelationship<TAuthor, TBook, TKey>(ModelBuilder modelBuilder)
            where TAuthor : AuthorReferencedBase<TKey>
            where TBook : BookReferencedBase<TKey>
        {
            modelBuilder.Entity<TBook>(e =>
            {
                if (e.Metadata.ClrType.GetProperty("ReferenceId").PropertyType == typeof(Ulid))
                {
                    e.Property(e => e.ReferenceId).HasConversion(new UlidToStringConverter());
                }
            });

            modelBuilder.Entity<TBook>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<TBook>()
                .HasIndex(b => b.Id)
                .IsUnique();

            modelBuilder.Entity<TBook>()
                .HasIndex(b => b.ReferenceId)
                .IsUnique();

            modelBuilder.Entity<TBook>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<TAuthor>(e =>
            {
                if (e.Metadata.ClrType.GetProperty("ReferenceId").PropertyType == typeof(Ulid))
                {
                    e.Property(e => e.ReferenceId).HasConversion(new UlidToStringConverter());
                }
            });

            modelBuilder.Entity<TAuthor>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<TAuthor>()
                .HasIndex(a => a.Id)
                .IsUnique();

            modelBuilder.Entity<TAuthor>()
                .HasIndex(a => a.ReferenceId)
                .IsUnique();

            modelBuilder.Entity<TAuthor>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<TAuthor>()
                .HasMany(a => (ICollection<TBook>)a.Books)
                .WithOne(b => (TAuthor)b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<Program>()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

    public class UlidToStringConverter : ValueConverter<Ulid, string>
    {
        public UlidToStringConverter()
            : base(ulid => ulid.ToString(), str => Ulid.Parse(str))
        { }
    }
}
