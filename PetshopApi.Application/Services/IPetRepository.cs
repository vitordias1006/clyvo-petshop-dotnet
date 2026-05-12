using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface IPetRepository
{
    IReadOnlyList<PetResponse> GetAll(); 
    IReadOnlyList<PetResponse> GetByUserId(Guid userId); 
    PetResponse? GetById(Guid id); 
    PetResponse Create(PetRequest r); 
    bool ExistsById(Guid id);
    bool Delete(Guid id);
    PetResponse Update(Guid id, PetRequest request);

}
