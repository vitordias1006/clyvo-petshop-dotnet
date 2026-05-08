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

    // GET api/pet
    [HttpGet]
    public IActionResult GetAll()
    {
        var pets = _petRepository.GetAll();
        return Ok(pets);
    }

    // GET api/pet/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var pet = _petRepository.GetById(id);
        if (pet is null)
            return NotFound();
        return Ok(pet);
    }

    // GET api/pet/user/{userId}
    [HttpGet("user/{userId:guid}")]
    public IActionResult GetByUserId(Guid userId)
    {
        var pets = _petRepository.GetByUserId(userId);
        return Ok(pets);
    }

    // POST api/pet
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

    // DELETE api/pet/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_petRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
}