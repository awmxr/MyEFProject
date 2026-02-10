using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEFProject.Model.Models;
using System.Reflection.Emit;

namespace MyEFProject.DataAccess.FluentConfigs;

public class Fluent_BookConfig : IEntityTypeConfiguration<Fluent_Book>
{
    public void Configure(EntityTypeBuilder<Fluent_Book> builder)
    {
        builder
            .HasKey(c => c.Book_Id);
        builder
            .Property(c => c.ISBN)
            .IsRequired()
            .HasMaxLength(15);
        builder
            .Property(c => c.Title).IsRequired()
            .HasMaxLength(400);
        builder
            .Property(c => c.Price).IsRequired();

        builder
          .HasOne(c => c.Fluent_BookDetail)
          .WithOne(c => c.Fluent_Book)
          .HasForeignKey<Fluent_Book>(c => c.BookDetail_Id);

        builder
            .HasOne(c => c.Fluent_Publisher)
            .WithMany(c => c.Fluent_Books)
            .HasForeignKey(c => c.Publisher_Id);
    }
}
