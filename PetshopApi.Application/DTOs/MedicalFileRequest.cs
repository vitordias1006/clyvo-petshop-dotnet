using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class MedicalFileRequest
{
    [Required] [StringLength(80)] public string Allergies { get; set; }
    [Required] [StringLength(80)] public string ChronicDiseases { get; set; }
    [Required] [StringLength(80)] public string Medicines { get; set; }
    [Required] public DateTime LastVaccine { get; set; }
    [Required] public DateTime NextVaccine { get; set; }
    [StringLength(200)] public string? Obs { get; set; }
    [Required] public Guid PetId { get; set; }
    public MedicalFile ToDomain() => new(Allergies, ChronicDiseases, Medicines, LastVaccine, NextVaccine, PetId, Obs);
}