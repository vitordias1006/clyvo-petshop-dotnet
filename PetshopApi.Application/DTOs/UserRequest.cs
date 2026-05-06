using System.ComponentModel.DataAnnotations;
using PetshopApi.Domain.Entities;

namespace PetshopApi.Application.DTOs;

public class UserRequest
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(80)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(13)]
    public string Telephone { get; set; }

    [Required]
    [StringLength(20)]
    public string Password { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    public User ToDomain() => new User(Name, Email, Telephone, Password, CreateDate);
}