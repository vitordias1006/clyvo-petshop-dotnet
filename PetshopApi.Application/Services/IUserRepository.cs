using PetshopApi.Application.DTOs;

namespace PetshopApi.Application.Services;

public interface IUserRepository
{
    IReadOnlyList<UserResponse> GetAll();
    UserResponse? GetById(Guid id);
    UserResponse Create(UserRequest request);
    bool ExistsById(Guid id);
    bool Delete(Guid id);
}