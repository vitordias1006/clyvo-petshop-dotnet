using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record OrderResponse(Guid Id, string Status, decimal TotalPrice, decimal? DiscountApplied, string DeliveryAddress, DateTime? CrateDate, Guid UserId)
{ public static OrderResponse FromDomain(Order o) => new(o.Id, o.Status, o.TotalPrice, o.DiscountApplied, o.DeliveryAddress, o.CrateDate, o.UserId); }