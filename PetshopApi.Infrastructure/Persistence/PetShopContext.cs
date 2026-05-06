using Microsoft.EntityFrameworkCore;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Infrastructure.Persistence;

public class PetShopContext(DbContextOptions<PetShopContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ItemOrder> ItemOrders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Signature> Signatures { get; set; }
    public DbSet<PlanData> PlanDatas { get; set; }
    public DbSet<MedicalFile> MedicalFiles { get; set; }
    public DbSet<Query> Queries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetShopContext).Assembly);
    }
}