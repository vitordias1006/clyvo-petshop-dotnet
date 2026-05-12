using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class ItemOrderRepository(PetShopContext context) : IItemOrderRepository
{
    public IReadOnlyList<ItemOrderResponse> GetAll()
    {
        return context.ItemOrders
            .Select(ItemOrderResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<ItemOrderResponse> GetByOrderId(Guid orderId)
    {
        return context.ItemOrders
            .Where(i => i.OrderId == orderId)
            .Select(ItemOrderResponse.FromDomain)
            .ToList();
    }

    public ItemOrderResponse? GetById(Guid id)
    {
        var item = context.ItemOrders.FirstOrDefault(i => i.Id == id);
        return item is null ? null : ItemOrderResponse.FromDomain(item);
    }

    public ItemOrderResponse Create(ItemOrderRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Quantity <= 0)
            throw new InvalidOperationException("A quantidade deve ser maior que zero");

        var item = request.ToDomain();
        context.ItemOrders.Add(item);
        context.SaveChanges();

        return ItemOrderResponse.FromDomain(item);
    }

    public bool ExistsById(Guid id)
    {
        return context.ItemOrders.Any(i => i.Id == id);
    }

    public bool Delete(Guid id)
    {
        var item = context.ItemOrders.FirstOrDefault(i => i.Id == id);
        if (item is null)
            return false;

        context.ItemOrders.Remove(item);
        context.SaveChanges();
        return true;
    }
    
    public ItemOrderResponse Update(Guid id, ItemOrderRequest request)
    {
        var item = context.ItemOrders.FirstOrDefault(i => i.Id == id);
        if (item is null)
            throw new KeyNotFoundException("Item do pedido não encontrado");

        if (request.Quantity <= 0)
            throw new InvalidOperationException("A quantidade deve ser maior que zero");

        item.Update(request.Quantity, request.UnitPrice, request.OrderId, request.ProductId);
        context.SaveChanges();

        return ItemOrderResponse.FromDomain(item);
    }
}