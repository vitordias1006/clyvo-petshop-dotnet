using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class Pet : BaseEntity
{
    public string Name { get; private set; }
    public string Species { get; private set; }
    public string Race { get; private set; }
    public DateTime BirthDate { get; private set; }
    public decimal Weight { get; private set; }
    public string PhotoUrl { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public MedicalFile MedicalFile { get; private set; }
    public ICollection<Query> Queries { get; private set; } = new List<Query>();

    public Pet(string name, string species, string race, DateTime birthDate, decimal weight, string photoUrl, Guid userId)
    {
        Name = name;
        Species = species;
        Race = race;
        BirthDate = birthDate;
        Weight = weight;
        PhotoUrl = photoUrl;
        UserId = userId;
    }
}