using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class PetRequest
{
    [Required] [StringLength(20)] 
    public string Name { get; set; }
    [Required] [StringLength(20)] 
    public string Species { get; set; }
    [Required] [StringLength(20)] 
    public string Race { get; set; }
    [Required] 
    public DateTime BirthDate { get; set; }
    [Required]
    public decimal Weight { get; set; }
    [Required] [StringLength(120)] 
    public string PhotoUrl { get; set; }
    [Required] 
    public Guid UserId { get; set; }
    
    public Pet ToDomain() => new(Name, Species, Race, BirthDate, Weight, PhotoUrl, UserId);
}