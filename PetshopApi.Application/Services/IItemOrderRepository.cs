using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface IItemOrderRepository
{
    IReadOnlyList<ItemOrderResponse> GetAll();
    IReadOnlyList<ItemOrderResponse> GetByOrderId(Guid orderId);
    ItemOrderResponse? GetById(Guid id); 
    ItemOrderResponse Create(ItemOrderRequest r);
    bool ExistsById(Guid id); bool Delete(Guid id);
}