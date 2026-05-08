using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class QueryRequest
{
    public DateTime? Time { get; set; }
    [Required] [StringLength(20)] public string Status { get; set; }
    [StringLength(200)] public string? Obs { get; set; }
    [Required] public Guid PetId { get; set; }
    public Query ToDomain() => new(Status, PetId, Time, Obs);
}