using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productRepository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var product = _productRepository.GetById(id);
        if (product is null)
            return NotFound();
        return Ok(product);
    }

    [HttpGet("category/{category}")]
    public IActionResult GetByCategory(string category)
    {
        var products = _productRepository.GetByCategory(category);
        return Ok(products);
    }

    [HttpGet("species/{species}")]
    public IActionResult GetBySpecies(string species)
    {
        var products = _productRepository.GetBySpecies(species);
        return Ok(products);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductRequest request)
    {
        try
        {
            var product = _productRepository.Create(request);
            return Created($"api/product/{product.Id}", product);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_productRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] ProductRequest request)
    {
        try
        {
            var product = _productRepository.Update(id, request);
            return Ok(product);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}