using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface IPlanDataRepository
{
    IReadOnlyList<PlanDataResponse> GetAll(); 
    IReadOnlyList<PlanDataResponse> GetBySignatureId(Guid sigId); 
    IReadOnlyList<PlanDataResponse> GetActive(); 
    PlanDataResponse? GetById(Guid id);
    PlanDataResponse Create(PlanDataRequest r);
    bool ExistsById(Guid id); bool Delete(Guid id);
}