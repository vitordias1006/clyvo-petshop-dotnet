using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record ProductResponse(Guid Id, string Name, string Description, string Category, string TargetSpecies, decimal Price, string ImgUrl, string Active)
{ public static ProductResponse FromDomain(Product p) => new(p.Id, p.Name, p.Description, p.Category, p.TargetSpecies, p.Price, p.ImgUrl, p.Active); }