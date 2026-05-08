using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class ProductRepository  (PetShopContext context) : IProductRepository
{
    public IReadOnlyList<ProductResponse> GetAll()
    {
        return context.Products
            .OrderBy(p => p.Name)
            .Select(ProductResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<ProductResponse> GetByCategory(string category)
    {
        return context.Products
            .Where(p => p.Category == category)
            .Select(ProductResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<ProductResponse> GetBySpecies(string species)
    {
        return context.Products
            .Where(p => p.TargetSpecies == species)
            .Select(ProductResponse.FromDomain)
            .ToList();
    }

    public ProductResponse? GetById(Guid id)
    {
        var product = context.Products.FirstOrDefault(p => p.Id == id);
        return product is null ? null : ProductResponse.FromDomain(product);
    }

    public ProductResponse Create(ProductRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Name))
            throw new InvalidOperationException("O nome do produto é obrigatório");

        var product = request.ToDomain();
        context.Products.Add(product);
        context.SaveChanges();

        return ProductResponse.FromDomain(product);
    }

    public bool ExistsById(Guid id)
    {
        return context.Products.Any(p => p.Id == id);
    }

    public bool Delete(Guid id)
    {
        var product = context.Products.FirstOrDefault(p => p.Id == id);
        if (product is null)
            return false;

        context.Products.Remove(product);
        context.SaveChanges();
        return true;
    }
}