using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record SignatureResponse(Guid Id, string Status, DateTime StartDate, DateTime EndDate, Guid UserId)
{ public static SignatureResponse FromDomain(Signature s) => new(s.Id, s.Status, s.StartDate, s.EndDate, s.UserId); }