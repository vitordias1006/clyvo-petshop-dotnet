using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class ProductRequest
{
    [Required] [StringLength(80)] public string Name { get; set; }
    [Required] [StringLength(150)] public string Description { get; set; }
    [Required] [StringLength(30)] public string Category { get; set; }
    [Required] [StringLength(30)] public string TargetSpecies { get; set; }
    [Required] public decimal Price { get; set; }
    [Required] [StringLength(180)] public string ImgUrl { get; set; }
    [Required] [StringLength(1)] public string Active { get; set; } = "Y";
    public Product ToDomain() => new(Name, Description, Category, TargetSpecies, Price, ImgUrl, Active);
}