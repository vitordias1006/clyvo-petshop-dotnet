using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface ISignatureRepository
{
    IReadOnlyList<SignatureResponse> GetAll(); 
    IReadOnlyList<SignatureResponse> GetByUserId(Guid userId); 
    SignatureResponse? GetById(Guid id);
    SignatureResponse Create(SignatureRequest r);
    bool ExistsById(Guid id); bool Delete(Guid id);
    SignatureResponse Update(Guid id, SignatureRequest request);
}