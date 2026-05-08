using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record PlanDataResponse(Guid Id, string Name, decimal MonthlyPrice, int? ConsultationsMonth, decimal? MktDiscount, string Benefits, string Active, Guid SignatureId)
{ public static PlanDataResponse FromDomain(PlanData p) => new(p.Id, p.Name, p.MonthlyPrice, p.ConsultationsMonth, p.MktDiscount, p.Benefits, p.Active, p.SignatureId); }