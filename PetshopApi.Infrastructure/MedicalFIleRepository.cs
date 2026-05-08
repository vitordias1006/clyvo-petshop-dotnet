using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class MedicalFileRepository(PetShopContext context) : IMedicalFileRepository
{
    public IReadOnlyList<MedicalFileResponse> GetAll()
    {
        return context.MedicalFiles
            .Select(MedicalFileResponse.FromDomain)
            .ToList();
    }

    public MedicalFileResponse? GetById(Guid id)
    {
        var medicalFile = context.MedicalFiles.FirstOrDefault(m => m.Id == id);
        return medicalFile is null ? null : MedicalFileResponse.FromDomain(medicalFile);
    }

    public MedicalFileResponse? GetByPetId(Guid petId)
    {
        var medicalFile = context.MedicalFiles.FirstOrDefault(m => m.PetId == petId);
        return medicalFile is null ? null : MedicalFileResponse.FromDomain(medicalFile);
    }

    public MedicalFileResponse Create(MedicalFileRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Allergies))
            throw new InvalidOperationException("O campo de alergias é obrigatório");

        var medicalFile = request.ToDomain();
        context.MedicalFiles.Add(medicalFile);
        context.SaveChanges();

        return MedicalFileResponse.FromDomain(medicalFile);
    }

    public bool ExistsById(Guid id)
    {
        return context.MedicalFiles.Any(m => m.Id == id);
    }

    public bool Delete(Guid id)
    {
        var medicalFile = context.MedicalFiles.FirstOrDefault(m => m.Id == id);
        if (medicalFile is null)
            return false;

        context.MedicalFiles.Remove(medicalFile);
        context.SaveChanges();
        return true;
    }
}