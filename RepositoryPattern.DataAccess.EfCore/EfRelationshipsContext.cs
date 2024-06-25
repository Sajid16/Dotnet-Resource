using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.DataAccess.EfCore
{
    public class EfRelationshipsContext : DbContext
    {
        public EfRelationshipsContext(DbContextOptions<EfRelationshipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public virtual DbSet<BookDetail> BookDetails { get; set; }
        public virtual DbSet<FluentAuthor> FluentAuthors { get; set; }
        public virtual DbSet<FluentBook> FluentBooks { get; set; }
        public virtual DbSet<FluentBookAuthorMap> FluentBookAuthorMaps { get; set; }
        public virtual DbSet<FluentBookDetail> FluentBookDetails { get; set; }
        public virtual DbSet<FluentPublisher> FluentPublishers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<SeriLog> SeriLogs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsCqr> StudentsCqrs { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.PublisherId, "IX_Books_Publisher_Id");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId);
            });

            modelBuilder.Entity<BookAuthorMap>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId });

                entity.HasIndex(e => e.AuthorId, "IX_BookAuthorMaps_Author_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthorMaps)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthorMaps)
                    .HasForeignKey(d => d.BookId);
            });

            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasIndex(e => e.BookId, "IX_BookDetails_Book_Id")
                    .IsUnique();

                entity.Property(e => e.BookDetailId).HasColumnName("BookDetail_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.BookDetail)
                    .HasForeignKey<BookDetail>(d => d.BookId);
            });

            modelBuilder.Entity<FluentAuthor>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<FluentBook>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.HasIndex(e => e.PublisherId, "IX_FluentBooks_Publisher_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.FluentBooks)
                    .HasForeignKey(d => d.PublisherId);
            });

            modelBuilder.Entity<FluentBookAuthorMap>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId });

                entity.ToTable("Fluent_BookAuthorMap");

                entity.HasIndex(e => e.AuthorId, "IX_Fluent_BookAuthorMap_Author_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.FluentBookAuthorMaps)
                    .HasForeignKey(d => d.AuthorId);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.FluentBookAuthorMaps)
                    .HasForeignKey(d => d.BookId);
            });

            modelBuilder.Entity<FluentBookDetail>(entity =>
            {
                entity.HasKey(e => e.BookDetailId);

                entity.HasIndex(e => e.BookId, "IX_FluentBookDetails_Book_Id")
                    .IsUnique();

                entity.Property(e => e.BookDetailId).HasColumnName("BookDetail_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.FluentBookDetail)
                    .HasForeignKey<FluentBookDetail>(d => d.BookId);
            });

            modelBuilder.Entity<FluentPublisher>(entity =>
            {
                entity.HasKey(e => e.PublisherId);

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SeriLog>(entity =>
            {
                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.GradeId, "IX_Students_GradeId");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategory_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }

    }
}
