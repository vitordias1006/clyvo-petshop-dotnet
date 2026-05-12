using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface IOrderRepository
{
    IReadOnlyList<OrderResponse> GetAll();
    IReadOnlyList<OrderResponse> GetByUserId(Guid userId);
    IReadOnlyList<OrderResponse> GetByStatus(string s); 
    OrderResponse? GetById(Guid id);
    OrderResponse Create(OrderRequest r);
    bool ExistsById(Guid id); bool Delete(Guid id);
    OrderResponse Update(Guid id, OrderRequest request);
}