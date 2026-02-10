using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEFProject.Model.Models;
using System.Reflection.Emit;

namespace MyEFProject.DataAccess.FluentConfigs;

public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
{
    public void Configure(EntityTypeBuilder<Fluent_Publisher> builder)
    {
        builder.HasKey(c => c.Publisher_Id);
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Location).IsRequired();
    }
}
