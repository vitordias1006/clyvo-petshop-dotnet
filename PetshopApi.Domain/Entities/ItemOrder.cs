using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class ItemOrder  : BaseEntity
{
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }

    public ItemOrder(int quantity, decimal unitPrice, Guid orderId, Guid productId)
    {
        Quantity = quantity;
        UnitPrice = unitPrice;
        OrderId = orderId;
        ProductId = productId;
    }
    
    public void Update(int quantity, decimal unitPrice, Guid orderId, Guid productId)
    {
        if (quantity <= 0)
            throw new InvalidOperationException("A quantidade deve ser maior que zero");

        if (unitPrice <= 0)
            throw new InvalidOperationException("O preço unitário deve ser maior que zero");

        if (orderId == Guid.Empty)
            throw new InvalidOperationException("O pedido é obrigatório");

        if (productId == Guid.Empty)
            throw new InvalidOperationException("O produto é obrigatório");

        Quantity = quantity;
        UnitPrice = unitPrice;
        OrderId = orderId;
        ProductId = productId;
    }
}