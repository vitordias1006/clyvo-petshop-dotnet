using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class Order :  BaseEntity
{
    public string Status { get; private set; }
    public decimal TotalPrice { get; private set; }
    public decimal? DiscountApplied { get; private set; }
    public string DeliveryAddress { get; private set; }
    public DateTime? CrateDate { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public ICollection<ItemOrder> Items { get; private set; } = new List<ItemOrder>();

    public Order(string status, decimal totalPrice, string deliveryAddress, Guid userId, decimal? discountApplied = null, DateTime? crateDate = null)
    {
        Status = status;
        TotalPrice = totalPrice;
        DeliveryAddress = deliveryAddress;
        UserId = userId;
        DiscountApplied = discountApplied;
        CrateDate = crateDate;
    }
    
    public void Update(string status, decimal totalPrice, string deliveryAddress, Guid userId, decimal? discountApplied, DateTime? crateDate)
    {
        if (string.IsNullOrWhiteSpace(status))
            throw new InvalidOperationException("O status é obrigatório");

        if (totalPrice < 0)
            throw new InvalidOperationException("O preço total não pode ser negativo");

        if (string.IsNullOrWhiteSpace(deliveryAddress))
            throw new InvalidOperationException("O endereço de entrega é obrigatório");

        if (userId == Guid.Empty)
            throw new InvalidOperationException("O usuário é obrigatório");

        Status = status;
        TotalPrice = totalPrice;
        DeliveryAddress = deliveryAddress;
        UserId = userId;
        DiscountApplied = discountApplied;
        CrateDate = crateDate;
    }
}