using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("PRODUCTS"); builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(p => p.Name).IsRequired().HasMaxLength(80);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Category).IsRequired().HasMaxLength(30);
        builder.Property(p => p.TargetSpecies).IsRequired().HasMaxLength(30);
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.ImgUrl).IsRequired().HasMaxLength(180);
        builder.Property(p => p.Active).IsRequired().HasMaxLength(1);
    }
}