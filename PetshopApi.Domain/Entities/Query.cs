using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class Query : BaseEntity
{
    public DateTime? Time { get; private set; }
    public string Status { get; private set; }
    public string? Obs { get; private set; }
    public Guid PetId { get; private set; }
    public Pet Pet { get; private set; }

    public Query(string status, Guid petId, DateTime? time = null, string? obs = null)
    {
        Status = status;
        PetId = petId;
        Time = time;
        Obs = obs;
    }
}