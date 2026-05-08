using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("ORDERS"); builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(o => o.UserId).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(o => o.Status).IsRequired().HasMaxLength(30);
        builder.Property(o => o.TotalPrice).IsRequired();
        builder.Property(o => o.DeliveryAddress).IsRequired().HasMaxLength(120);
        builder.HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderId).OnDelete(DeleteBehavior.Cascade);
    }
}