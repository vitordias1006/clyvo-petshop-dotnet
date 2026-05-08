using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record ItemOrderResponse(Guid Id, int Quantity, decimal UnitPrice, Guid OrderId, Guid ProductId)
{ public static ItemOrderResponse FromDomain(ItemOrder i) => new(i.Id, i.Quantity, i.UnitPrice, i.OrderId, i.ProductId); }