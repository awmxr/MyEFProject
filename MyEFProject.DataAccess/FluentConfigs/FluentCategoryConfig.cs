using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEFProject.Model.Models;
using System.Reflection.Emit;

namespace MyEFProject.DataAccess.FluentConfigs;

public class FluentCategoryConfig : IEntityTypeConfiguration<Fluent_Category>
{
    public void Configure(EntityTypeBuilder<Fluent_Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.ToTable("tbl_CategoryFluent");
        builder.Property(c => c.Name).HasColumnName("CategoryName");
    }
}
