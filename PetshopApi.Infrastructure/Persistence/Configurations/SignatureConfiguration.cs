using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence.Configurations;

public class SignatureConfiguration : IEntityTypeConfiguration<Signature>
{
    public void Configure(EntityTypeBuilder<Signature> builder)
    {
        builder.ToTable("SIGNATURES"); builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(s => s.UserId).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(s => s.Status).IsRequired().HasMaxLength(30);
        builder.Property(s => s.StartDate).IsRequired();
        builder.Property(s => s.EndDate).IsRequired();
        builder.HasMany(s => s.Plans).WithOne(p => p.Signature).HasForeignKey(p => p.SignatureId).OnDelete(DeleteBehavior.Cascade);
    }
}