using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface IQueryRepository
{
    IReadOnlyList<QueryResponse> GetAll(); 
    IReadOnlyList<QueryResponse> GetByPetId(Guid petId);
    IReadOnlyList<QueryResponse> GetByStatus(string s);
    QueryResponse? GetById(Guid id);
    QueryResponse Create(QueryRequest r);
    bool ExistsById(Guid id); bool Delete(Guid id);
}