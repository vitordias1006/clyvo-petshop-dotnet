using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class ItemOrderRequest
{
    [Required] [Range(1, 99)] public int Quantity { get; set; }
    [Required] public decimal UnitPrice { get; set; }
    [Required] public Guid OrderId { get; set; }
    [Required] public Guid ProductId { get; set; }
    public ItemOrder ToDomain() => new(Quantity, UnitPrice, OrderId, ProductId);
}