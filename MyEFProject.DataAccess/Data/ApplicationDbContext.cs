using Microsoft.EntityFrameworkCore;
using MyEFProject.Model.Models;

namespace MyEFProject.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookDetail> BookDetails { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
    public DbSet<Fluent_Book> Fluent_Books { get; set; }
    public DbSet<Fluent_Author> Fluent_Author { get; set; }
    public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
    public DbSet<Fluent_Category> Fluent_Categories { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(b => new { b.Author_Id, b.Book_Id });
        //base.OnModelCreating(modelBuilder);



        #region Fluent_BookDetail

        modelBuilder.Entity<Fluent_BookDetail>()
            .HasKey(b => b.BookDetail_Id);
        modelBuilder.Entity<Fluent_BookDetail>()
            .Property(c => c.NumberOfChapters).IsRequired();

        #endregion


        #region Fluent_Book
        modelBuilder.Entity<Fluent_Book>()
            .HasKey(c => c.Book_Id);
        modelBuilder.Entity<Fluent_Book>()
            .Property(c => c.ISBN)
            .IsRequired()
            .HasMaxLength(15);
        modelBuilder.Entity<Fluent_Book>()
            .Property(c=> c.Title).IsRequired()
            .HasMaxLength(400);
        modelBuilder.Entity<Fluent_Book>()
            .Property(c => c.Price).IsRequired();


        #endregion

        #region Fluent_Author
        modelBuilder.Entity<Fluent_Author>()
            .HasKey(c => c.Author_Id);
        modelBuilder.Entity<Fluent_Author>()
            .Property(c => c.FirstName).IsRequired();
        modelBuilder.Entity<Fluent_Author>()
            .Property(c => c.LastName).IsRequired();

        modelBuilder.Entity<Fluent_Author>().Ignore(c => c.FullName);
        #endregion

        #region Fluent_Publisher
        modelBuilder.Entity<Fluent_Publisher>()
            .HasKey(c => c.Publisher_Id);
        modelBuilder.Entity<Fluent_Publisher>()
            .Property(c=> c.Name).IsRequired();
        modelBuilder.Entity<Fluent_Publisher>()
            .Property(c => c.Location).IsRequired();
        #endregion

        #region Fluent_Category
        modelBuilder.Entity<Fluent_Category>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Fluent_Category>()
            .ToTable("tbl_CategoryFluent");
        modelBuilder.Entity<Fluent_Category>()
            .Property(c=> c.Name).HasColumnName("CategoryName");    

        #endregion
    }



}
