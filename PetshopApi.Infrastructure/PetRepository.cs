using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class PetRepository(PetShopContext context) : IPetRepository
{
    public IReadOnlyList<PetResponse> GetAll()
    {
        return context.Pets
            .OrderBy(p => p.Name)
            .Select(PetResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<PetResponse> GetByUserId(Guid userId)
    {
        return context.Pets
            .Where(p => p.UserId == userId)
            .Select(PetResponse.FromDomain)
            .ToList();
    }

    public PetResponse? GetById(Guid id)
    {
        var pet = context.Pets.FirstOrDefault(p => p.Id == id);
        return pet is null ? null : PetResponse.FromDomain(pet);
    }

    public PetResponse Create(PetRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Name))
            throw new InvalidOperationException("O nome do pet é obrigatório");

        var pet = request.ToDomain();
        context.Pets.Add(pet);
        context.SaveChanges();

        return PetResponse.FromDomain(pet);
    }

    public bool ExistsById(Guid id)
    {
        return context.Pets.Any(p => p.Id == id);
    }

    public bool Delete(Guid id)
    {
        var pet = context.Pets.FirstOrDefault(p => p.Id == id);
        if (pet is null)
            return false;

        context.Pets.Remove(pet);
        context.SaveChanges();
        return true;
    }
}