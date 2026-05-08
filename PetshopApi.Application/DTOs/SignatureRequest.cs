using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class SignatureRequest
{
    [Required] [StringLength(30)] public string Status { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
    [Required] public Guid UserId { get; set; }
    public Signature ToDomain() => new(Status, StartDate, EndDate, UserId);
}