using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence.Configurations;

public class QueryConfiguration : IEntityTypeConfiguration<Query>
{
    public void Configure(EntityTypeBuilder<Query> builder)
    {
        builder.ToTable("QUERIES"); builder.HasKey(q => q.Id);
        builder.Property(q => q.Id).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(q => q.PetId).HasConversion(v => v.ToByteArray(), v => new Guid(v));
        builder.Property(q => q.Status).IsRequired().HasMaxLength(20);
        builder.Property(q => q.Obs).HasMaxLength(200);
    }
}