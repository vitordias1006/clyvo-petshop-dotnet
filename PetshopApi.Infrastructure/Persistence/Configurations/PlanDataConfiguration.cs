using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence.Configurations;

public class PlanDataConfiguration : IEntityTypeConfiguration<PlanData>
{
    public void Configure(EntityTypeBuilder<PlanData> builder)
    {
        builder.ToTable("PLAN_DATAS"); builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(p => p.SignatureId).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Property(p => p.MonthlyPrice).IsRequired();
        builder.Property(p => p.Benefits).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Active).IsRequired().HasMaxLength(1);
    }
}