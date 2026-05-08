using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record PetResponse(Guid Id, string Name, string Species, string Race, DateTime BirthDate, decimal Weight, string PhotoUrl, Guid UserId)
{ public static PetResponse FromDomain(Pet p) => new(p.Id, p.Name, p.Species, p.Race, p.BirthDate, p.Weight, p.PhotoUrl, p.UserId); }