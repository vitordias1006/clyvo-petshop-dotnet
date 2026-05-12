using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class OrderRepository(PetShopContext context) : IOrderRepository
{
    public IReadOnlyList<OrderResponse> GetAll()
    {
        return context.Orders
            .OrderBy(o => o.Status)
            .Select(OrderResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<OrderResponse> GetByUserId(Guid userId)
    {
        return context.Orders
            .Where(o => o.UserId == userId)
            .Select(OrderResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<OrderResponse> GetByStatus(string status)
    {
        return context.Orders
            .Where(o => o.Status == status)
            .Select(OrderResponse.FromDomain)
            .ToList();
    }

    public OrderResponse? GetById(Guid id)
    {
        var order = context.Orders.FirstOrDefault(o => o.Id == id);
        return order is null ? null : OrderResponse.FromDomain(order);
    }

    public OrderResponse Create(OrderRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.DeliveryAddress))
            throw new InvalidOperationException("O endereço de entrega é obrigatório");

        var order = request.ToDomain();
        context.Orders.Add(order);
        context.SaveChanges();

        return OrderResponse.FromDomain(order);
    }

    public bool ExistsById(Guid id)
    {
        return context.Orders.Any(o => o.Id == id);
    }

    public bool Delete(Guid id)
    {
        var order = context.Orders.FirstOrDefault(o => o.Id == id);
        if (order is null)
            return false;

        context.Orders.Remove(order);
        context.SaveChanges();
        return true;
    }
    
    public OrderResponse Update(Guid id, OrderRequest request)
    {
        var order = context.Orders.FirstOrDefault(o => o.Id == id);
        if (order is null)
            throw new KeyNotFoundException("Pedido não encontrado");

        if (string.IsNullOrWhiteSpace(request.DeliveryAddress))
            throw new InvalidOperationException("O endereço de entrega é obrigatório");

        order.Update(request.Status, request.TotalPrice, request.DeliveryAddress, request.UserId, request.DiscountApplied, request.CrateDate);
        context.SaveChanges();

        return OrderResponse.FromDomain(order);
    }
}