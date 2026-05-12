using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class UserRepository(PetShopContext context) : IUserRepository
{
    public IReadOnlyList<UserResponse> GetAll()
    {
        return context.Users
            .OrderBy(u => u.Name)
            .Select(UserResponse.FromDomain)
            .ToList();
    }

    public UserResponse? GetById(Guid id)
    {
        var user = context.Users.FirstOrDefault(u => u.Id == id);
        return user is null ? null : UserResponse.FromDomain(user);
    }

    public UserResponse Create(UserRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Name))
            throw new InvalidOperationException("O nome do usuário é obrigatório");

        var user = request.ToDomain();
        context.Users.Add(user);
        context.SaveChanges();

        return UserResponse.FromDomain(user);
    }

    public bool ExistsById(Guid id)
    {
        return context.Users.Any(u => u.Id == id);
    }

    public bool Delete(Guid id)
    {
        var user = context.Users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            return false;

        context.Users.Remove(user);
        context.SaveChanges();
        return true;
    }
    
    public UserResponse Update(Guid id, UserRequest request)
    {
        var user = context.Users.FirstOrDefault(u => u.Id == id);
        if (user is null)
            throw new KeyNotFoundException("Usuário não encontrado");

        if (string.IsNullOrWhiteSpace(request.Name))
            throw new InvalidOperationException("O nome do usuário é obrigatório");

        user.Update(request.Name, request.Email, request.Telephone, request.Password, request.CreateDate);
        context.SaveChanges();

        return UserResponse.FromDomain(user);
    }
}