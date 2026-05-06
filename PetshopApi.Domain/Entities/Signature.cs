using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class Signature  : BaseEntity
{
    public string Status { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public ICollection<PlanData> Plans { get; private set; } = new List<PlanData>();

    public Signature(string status, DateTime startDate, DateTime endDate, Guid userId)
    {
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
        UserId = userId;
    }
}