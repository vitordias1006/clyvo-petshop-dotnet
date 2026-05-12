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
    
    public void Update(string name, decimal monthlyPrice, string benefits, string active, Guid signatureId, int? consultationsMonth, decimal? mktDiscount)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("O nome do plano é obrigatório");

        if (monthlyPrice <= 0)
            throw new InvalidOperationException("O preço mensal deve ser maior que zero");

        if (string.IsNullOrWhiteSpace(benefits))
            throw new InvalidOperationException("Os benefícios são obrigatórios");

        if (active != "S" && active != "N")
            throw new InvalidOperationException("O campo active deve ser S ou N");

        if (signatureId == Guid.Empty)
            throw new InvalidOperationException("A assinatura é obrigatória");

        if (consultationsMonth.HasValue && consultationsMonth <= 0)
            throw new InvalidOperationException("O número de consultas deve ser maior que zero");

        if (mktDiscount.HasValue && (mktDiscount < 0 || mktDiscount > 100))
            throw new InvalidOperationException("O desconto deve estar entre 0 e 100");

        Name = name;
        MonthlyPrice = monthlyPrice;
        Benefits = benefits;
        Active = active;
        SignatureId = signatureId;
        ConsultationsMonth = consultationsMonth;
        MktDiscount = mktDiscount;
    }
}