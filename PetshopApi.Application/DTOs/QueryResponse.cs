using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record QueryResponse(Guid Id, DateTime? Time, string Status, string? Obs, Guid PetId)
{ public static QueryResponse FromDomain(Query q) => new(q.Id, q.Time, q.Status, q.Obs, q.PetId); }