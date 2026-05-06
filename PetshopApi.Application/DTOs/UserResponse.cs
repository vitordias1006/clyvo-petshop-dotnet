using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record UserResponse( 
    Guid Id,
    string Name,
    string Email,
    string Telephone,
    DateTime CreateDate)
{
    public static UserResponse FromDomain(User user) =>
        new(user.Id, user.Name, user.Email, user.Telephone, user.CreateDate);
}