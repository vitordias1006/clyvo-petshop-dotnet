using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("PETS"); builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(p => p.UserId).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Species).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Race).IsRequired().HasMaxLength(20);
        builder.Property(p => p.BirthDate).IsRequired();
        builder.Property(p => p.Weight).IsRequired();
        builder.Property(p => p.PhotoUrl).IsRequired().HasMaxLength(120);
        builder.HasOne(p => p.MedicalFile).WithOne(m => m.Pet).HasForeignKey<MedicalFile>(m => m.PetId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.Queries).WithOne(q => q.Pet).HasForeignKey(q => q.PetId).OnDelete(DeleteBehavior.Cascade);
    }
}