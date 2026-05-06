using PetshopApi.Domain.Common;

namespace PetshopApi.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string TargetSpecies { get; private set; }
    public decimal Price { get; private set; }
    public string ImgUrl { get; private set; }
    public string Active { get; private set; }

    public Product(string name, string description, string category, string targetSpecies, decimal price, string imgUrl, string active)
    {
        Name = name;
        Description = description;
        Category = category;
        TargetSpecies = targetSpecies;
        Price = price;
        ImgUrl = imgUrl;
        Active = active;
    }
}