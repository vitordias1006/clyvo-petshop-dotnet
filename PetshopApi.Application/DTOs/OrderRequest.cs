using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class OrderRequest
{
    [Required] [StringLength(30)] public string Status { get; set; }
    [Required] public decimal TotalPrice { get; set; }
    public decimal? DiscountApplied { get; set; }
    [Required] [StringLength(120)] public string DeliveryAddress { get; set; }
    public DateTime? CrateDate { get; set; }
    [Required] public Guid UserId { get; set; }
    public Order ToDomain() => new(Status, TotalPrice, DeliveryAddress, UserId, DiscountApplied, CrateDate);
}