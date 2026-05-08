using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public record MedicalFileResponse(Guid Id, string Allergies, string ChronicDiseases, string Medicines, DateTime LastVaccine, DateTime NextVaccine, string? Obs, Guid PetId)
{ public static MedicalFileResponse FromDomain(MedicalFile m) => new(m.Id, m.Allergies, m.ChronicDiseases, m.Medicines, m.LastVaccine, m.NextVaccine, m.Obs, m.PetId); }