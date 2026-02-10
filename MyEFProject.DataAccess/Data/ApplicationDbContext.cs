using Microsoft.EntityFrameworkCore;
using MyEFProject.DataAccess.FluentConfigs;
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
    public DbSet<Fluent_BookAuthor> Fluent_BookAuthors { get; set; }




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


    

        #region Fluent_Author
        modelBuilder.Entity<Fluent_Author>()
            .HasKey(c => c.Author_Id);
        modelBuilder.Entity<Fluent_Author>()
            .Property(c => c.FirstName).IsRequired();
        modelBuilder.Entity<Fluent_Author>()
            .Property(c => c.LastName).IsRequired();

        modelBuilder.Entity<Fluent_Author>().Ignore(c => c.FullName);
        #endregion

      

        

       


        modelBuilder.ApplyConfiguration(new Fluent_BookAuthorConfig());
        modelBuilder.ApplyConfiguration(new FluentCategoryConfig());
        modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
        modelBuilder.ApplyConfiguration(new Fluent_BookConfig());
        
    }



}
