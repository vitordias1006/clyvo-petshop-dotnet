using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Telephone { get; private set; }
    public string Password { get; private set; }
    public DateTime CreateDate { get; private set; }

    public ICollection<Pet> Pets { get; private set; } = new List<Pet>();
    public ICollection<Order> Orders { get; private set; } = new List<Order>();
    public ICollection<Signature> Signatures { get; private set; } = new List<Signature>();

    public User(string name, string email, string telephone, string password, DateTime createDate)
    {
        Name = name;
        Email = email;
        Telephone = telephone;
        Password = password;
        CreateDate = createDate;
    }
    
    public void Update(string name, string email, string telephone, string password, DateTime createDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("O nome do usuário é obrigatório");

        if (string.IsNullOrWhiteSpace(email))
            throw new InvalidOperationException("O email é obrigatório");

        if (string.IsNullOrWhiteSpace(telephone))
            throw new InvalidOperationException("O telefone é obrigatório");

        if (string.IsNullOrWhiteSpace(password))
            throw new InvalidOperationException("A senha é obrigatória");

        Name = name;
        Email = email;
        Telephone = telephone;
        Password = password;
        CreateDate = createDate;
    }
}