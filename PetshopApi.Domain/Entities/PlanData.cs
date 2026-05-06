using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class PlanData : BaseEntity
{
    public string Name { get; private set; }
    public decimal MonthlyPrice { get; private set; }
    public int? ConsultationsMonth { get; private set; }
    public decimal? MktDiscount { get; private set; }
    public string Benefits { get; private set; }
    public string Active { get; private set; }
    public Guid SignatureId { get; private set; }
    public Signature Signature { get; private set; }

    public PlanData(string name, decimal monthlyPrice, string benefits, string active, Guid signatureId, int? consultationsMonth = null, decimal? mktDiscount = null)
    {
        Name = name;
        MonthlyPrice = monthlyPrice;
        Benefits = benefits;
        Active = active;
        SignatureId = signatureId;
        ConsultationsMonth = consultationsMonth;
        MktDiscount = mktDiscount;
    }
}