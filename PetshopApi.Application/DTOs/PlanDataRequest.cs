using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class PlanDataRequest
{
    [Required] [StringLength(30)] public string Name { get; set; }
    [Required] public decimal MonthlyPrice { get; set; }
    public int? ConsultationsMonth { get; set; }
    public decimal? MktDiscount { get; set; }
    [Required] [StringLength(150)] public string Benefits { get; set; }
    [Required] [StringLength(1)] public string Active { get; set; } = "Y";
    [Required] public Guid SignatureId { get; set; }

    public PlanData ToDomain() =>
        new(Name, MonthlyPrice, Benefits, Active, SignatureId, ConsultationsMonth, MktDiscount);
}