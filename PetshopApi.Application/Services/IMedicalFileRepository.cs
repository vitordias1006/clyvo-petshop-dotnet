using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface IMedicalFileRepository
{
    IReadOnlyList<MedicalFileResponse> GetAll(); 
    MedicalFileResponse? GetById(Guid id);
    MedicalFileResponse? GetByPetId(Guid petId); 
    MedicalFileResponse Create(MedicalFileRequest r); 
    bool ExistsById(Guid id); bool Delete(Guid id);
    MedicalFileResponse Update(Guid id, MedicalFileRequest request);
}