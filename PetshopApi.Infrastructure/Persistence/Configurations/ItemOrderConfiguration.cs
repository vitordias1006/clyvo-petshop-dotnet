using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence.Configurations;

public class ItemOrderConfiguration
{
    public void Configure(EntityTypeBuilder<ItemOrder> builder)
    {
        builder.ToTable("ITEM_ORDERS"); builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(i => i.OrderId).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(i => i.ProductId).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(i => i.Quantity).IsRequired();
        builder.Property(i => i.UnitPrice).IsRequired();
        builder.HasOne(i => i.Product).WithMany().HasForeignKey(i => i.ProductId).OnDelete(DeleteBehavior.Restrict);
    }
}