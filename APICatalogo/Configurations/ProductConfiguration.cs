using APICatalogo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);

        builder.Property(p => p.Name)
               .IsRequired() 
               .HasMaxLength(80); 

        builder.Property(p => p.ImageUrl)
               .HasMaxLength(300);         
        
        builder.Property(p => p.Description)
               .HasMaxLength(300); 

        builder.Property(p => p.Price)
               .HasColumnType("decimal(10,2)");
    }
}
