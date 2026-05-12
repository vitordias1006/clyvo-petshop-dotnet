using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class PlanDataRepository(PetShopContext context) : IPlanDataRepository
{
    public IReadOnlyList<PlanDataResponse> GetAll()
    {
        return context.PlanDatas
            .OrderBy(p => p.Name)
            .Select(PlanDataResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<PlanDataResponse> GetBySignatureId(Guid signatureId)
    {
        return context.PlanDatas
            .Where(p => p.SignatureId == signatureId)
            .Select(PlanDataResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<PlanDataResponse> GetActive()
    {
        return context.PlanDatas
            .Where(p => p.Active == "Y")
            .Select(PlanDataResponse.FromDomain)
            .ToList();
    }

    public PlanDataResponse? GetById(Guid id)
    {
        var plan = context.PlanDatas.FirstOrDefault(p => p.Id == id);
        return plan is null ? null : PlanDataResponse.FromDomain(plan);
    }

    public PlanDataResponse Create(PlanDataRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Name))
            throw new InvalidOperationException("O nome do plano é obrigatório");

        var plan = request.ToDomain();
        context.PlanDatas.Add(plan);
        context.SaveChanges();

        return PlanDataResponse.FromDomain(plan);
    }

    public bool ExistsById(Guid id)
    {
        return context.PlanDatas.Any(p => p.Id == id);
    }

    public bool Delete(Guid id)
    {
        var plan = context.PlanDatas.FirstOrDefault(p => p.Id == id);
        if (plan is null)
            return false;

        context.PlanDatas.Remove(plan);
        context.SaveChanges();
        return true;
    }
    
    public PlanDataResponse Update(Guid id, PlanDataRequest request)
    {
        var plan = context.PlanDatas.FirstOrDefault(p => p.Id == id);
        if (plan is null)
            throw new KeyNotFoundException("Plano não encontrado");

        if (string.IsNullOrWhiteSpace(request.Name))
            throw new InvalidOperationException("O nome do plano é obrigatório");

        plan.Update(request.Name, request.MonthlyPrice, request.Benefits, request.Active, request.SignatureId, request.ConsultationsMonth, request.MktDiscount);
        context.SaveChanges();

        return PlanDataResponse.FromDomain(plan);
    }
}