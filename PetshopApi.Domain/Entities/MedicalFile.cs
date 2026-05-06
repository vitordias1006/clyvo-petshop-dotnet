using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class MedicalFile : BaseEntity
{
    public string Allergies { get; private set; }
    public string ChronicDiseases { get; private set; }
    public string Medicines { get; private set; }
    public DateTime LastVaccine { get; private set; }
    public DateTime NextVaccine { get; private set; }
    public string? Obs { get; private set; }
    public Guid PetId { get; private set; }
    public Pet Pet { get; private set; }

    public MedicalFile(string allergies, string chronicDiseases, string medicines, DateTime lastVaccine, DateTime nextVaccine, Guid petId, string? obs = null)
    {
        Allergies = allergies;
        ChronicDiseases = chronicDiseases;
        Medicines = medicines;
        LastVaccine = lastVaccine;
        NextVaccine = nextVaccine;
        PetId = petId;
        Obs = obs;
    }
}