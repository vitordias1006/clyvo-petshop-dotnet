using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence.Configurations;

public class MedicalFileConfiguration : IEntityTypeConfiguration<MedicalFile>
{
    public void Configure(EntityTypeBuilder<MedicalFile> builder)
    {
        builder.ToTable("MEDICAL_FILES"); builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(m => m.PetId).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(m => m.Allergies).IsRequired().HasMaxLength(80);
        builder.Property(m => m.ChronicDiseases).IsRequired().HasMaxLength(80);
        builder.Property(m => m.Medicines).IsRequired().HasMaxLength(80);
        builder.Property(m => m.LastVaccine).IsRequired();
        builder.Property(m => m.NextVaccine).IsRequired();
        builder.Property(m => m.Obs).HasMaxLength(200);
    }
}