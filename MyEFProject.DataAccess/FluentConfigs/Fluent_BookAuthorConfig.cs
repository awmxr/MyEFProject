using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEFProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace MyEFProject.DataAccess.FluentConfigs
{
    public class Fluent_BookAuthorConfig : IEntityTypeConfiguration<Fluent_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthor> builder)
        {
            builder
          .HasKey(c => new { c.Author_Id, c.Book_Id });

            builder
                .HasOne(c => c.Fluent_Book)
                .WithMany(c => c.Fluent_BookAuthors)
                .HasForeignKey(c => c.Book_Id);

            builder
               .HasOne(c => c.Fluent_Author)
               .WithMany(c => c.Fluent_BookAuthors)
               .HasForeignKey(c => c.Author_Id);
        }
    }
}
