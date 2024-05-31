using Microsoft.EntityFrameworkCore;

namespace EfConventionalRelationships.Data
{
    public class RelatonshipsContext : DbContext
    {
        public RelatonshipsContext(DbContextOptions<RelatonshipsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>()
            //    .HasOne<Grade>(s => s.Grade)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey(s => s.GradeId);
             
            modelBuilder.Entity<Book>()
                .Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(val => new { val.Book_Id, val.Author_Id });

            // using fluent api to configure entities

            modelBuilder.Entity<Fluent_Book>().ToTable("FluentBooks");
            modelBuilder.Entity<Fluent_Book>().HasKey(p => p.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Property(p => p.ISBN).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Fluent_Book>().HasOne(p => p.Publisher)
                                              .WithMany(p => p.books)
                                              .HasForeignKey(p => p.Publisher_Id);

            modelBuilder.Entity<Fluent_BookDetail>().ToTable("FluentBookDetails");
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(p => p.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(p => p.Book)
                                                    .WithOne(p => p.BookDetail)
                                                    .HasForeignKey<Fluent_BookDetail>(p => p.Book_Id);

            modelBuilder.Entity<Fluent_Author>().ToTable("FluentAuthors");
            modelBuilder.Entity<Fluent_Author>().HasKey(p => p.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Fluent_Author>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(p => p.FullName);

            modelBuilder.Entity<Fluent_Publisher>().ToTable("FluentPublishers");
            modelBuilder.Entity<Fluent_Publisher>().HasKey(p => p.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(p => p.Name).IsRequired();
            
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(val => new { val.Book_Id, val.Author_Id });
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(p=> p.Book)
                                                       .WithMany(p=>p.fluent_BookAuthorMaps)
                                                       .HasForeignKey(p=>p.Book_Id);
            modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(p => p.Author)
                                                       .WithMany(p => p.fluent_BookAuthorMaps)
                                                       .HasForeignKey(p => p.Author_Id);

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<BookDetail> BookDetails { get; set; }
        public virtual DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public virtual DbSet<Fluent_Book> Fluent_Books { get; set; }
        public virtual DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public virtual DbSet<Fluent_Author> Fluent_Authors { get; set; }
    }
}
