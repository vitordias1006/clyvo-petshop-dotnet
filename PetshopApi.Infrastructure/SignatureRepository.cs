using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class SignatureRepository(PetShopContext context) : ISignatureRepository
{
    public IReadOnlyList<SignatureResponse> GetAll()
    {
        return context.Signatures
            .OrderBy(s => s.Status)
            .Select(SignatureResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<SignatureResponse> GetByUserId(Guid userId)
    {
        return context.Signatures
            .Where(s => s.UserId == userId)
            .Select(SignatureResponse.FromDomain)
            .ToList();
    }

    public SignatureResponse? GetById(Guid id)
    {
        var signature = context.Signatures.FirstOrDefault(s => s.Id == id);
        return signature is null ? null : SignatureResponse.FromDomain(signature);
    }

    public SignatureResponse Create(SignatureRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Status))
            throw new InvalidOperationException("O status da assinatura é obrigatório");

        var signature = request.ToDomain();
        context.Signatures.Add(signature);
        context.SaveChanges();

        return SignatureResponse.FromDomain(signature);
    }

    public bool ExistsById(Guid id)
    {
        return context.Signatures.Any(s => s.Id == id);
    }

    public bool Delete(Guid id)
    {
        var signature = context.Signatures.FirstOrDefault(s => s.Id == id);
        if (signature is null)
            return false;

        context.Signatures.Remove(signature);
        context.SaveChanges();
        return true;
    }
    
    public SignatureResponse Update(Guid id, SignatureRequest request)
    {
        var signature = context.Signatures.FirstOrDefault(s => s.Id == id);
        if (signature is null)
            throw new KeyNotFoundException("Assinatura não encontrada");

        if (string.IsNullOrWhiteSpace(request.Status))
            throw new InvalidOperationException("O status da assinatura é obrigatório");

        signature.Update(request.Status, request.StartDate, request.EndDate, request.UserId);
        context.SaveChanges();

        return SignatureResponse.FromDomain(signature);
    }
}