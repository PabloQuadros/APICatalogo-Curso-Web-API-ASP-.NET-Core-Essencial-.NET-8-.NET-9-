using APICatalogo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.CategoryId);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(80);

        builder.Property(c => c.ImageUrl)
               .HasMaxLength(300);
    }
}