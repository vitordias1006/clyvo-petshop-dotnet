using Microsoft.EntityFrameworkCore;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Oracle + EF Core
        builder.Services.AddDbContext<PetShopContext>(options =>
        {
            options.UseOracle(builder.Configuration.GetConnectionString("PetshopOracle"));
        });

        // Injeção de dependência — registrar todos os repositórios
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        // builder.Services.AddScoped<IPetRepository, PetRepository>();
        // builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        // builder.Services.AddScoped<IProductRepository, ProductRepository>();
        // builder.Services.AddScoped<ISignatureRepository, SignatureRepository>();
        // builder.Services.AddScoped<IPlanDataRepository, PlanDataRepository>();
        // builder.Services.AddScoped<IMedicalFileRepository, MedicalFileRepository>();
        // builder.Services.AddScoped<IQueryRepository, QueryRepository>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}