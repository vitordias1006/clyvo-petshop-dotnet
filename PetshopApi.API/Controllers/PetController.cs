using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    private readonly IPetRepository _petRepository;

    public PetController(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pets = _petRepository.GetAll();
        return Ok(pets);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var pet = _petRepository.GetById(id);
        if (pet is null)
            return NotFound();
        return Ok(pet);
    }

    [HttpGet("user/{userId:guid}")]
    public IActionResult GetByUserId(Guid userId)
    {
        var pets = _petRepository.GetByUserId(userId);
        return Ok(pets);
    }

    [HttpPost]
    public IActionResult Create([FromBody] PetRequest request)
    {
        try
        {
            var pet = _petRepository.Create(request);
            return Created($"api/pet/{pet.Id}", pet);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_petRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] PetRequest request)
    {
        try
        {
            var pet = _petRepository.Update(id, request);
            return Ok(pet);
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