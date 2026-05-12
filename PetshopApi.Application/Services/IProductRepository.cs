using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface IProductRepository
{
    IReadOnlyList<ProductResponse> GetAll();
    IReadOnlyList<ProductResponse> GetByCategory(string c); 
    IReadOnlyList<ProductResponse> GetBySpecies(string s); 
    ProductResponse? GetById(Guid id);
    ProductResponse Create(ProductRequest r); 
    bool ExistsById(Guid id); bool Delete(Guid id);
    ProductResponse Update(Guid id, ProductRequest request);
}