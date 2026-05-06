using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // GET api/user
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userRepository.GetAll();
        return Ok(users);
    }

    // GET api/user/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var user = _userRepository.GetById(id);
        if (user is null)
            return NotFound();
        return Ok(user);
    }

    // POST api/user
    [HttpPost]
    public IActionResult Create([FromBody] UserRequest request)
    {
        try
        {
            var user = _userRepository.Create(request);
            return Created($"api/user/{user.Id}", user);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/user/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_userRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
}