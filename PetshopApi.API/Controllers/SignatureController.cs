using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SignatureController : ControllerBase
{
    private readonly ISignatureRepository _signatureRepository;

    public SignatureController(ISignatureRepository signatureRepository)
    {
        _signatureRepository = signatureRepository;
    }

    // GET api/signature
    [HttpGet]
    public IActionResult GetAll()
    {
        var signatures = _signatureRepository.GetAll();
        return Ok(signatures);
    }

    // GET api/signature/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var signature = _signatureRepository.GetById(id);
        if (signature is null)
            return NotFound();
        return Ok(signature);
    }

    // GET api/signature/user/{userId}
    [HttpGet("user/{userId:guid}")]
    public IActionResult GetByUserId(Guid userId)
    {
        var signatures = _signatureRepository.GetByUserId(userId);
        return Ok(signatures);
    }

    // POST api/signature
    [HttpPost]
    public IActionResult Create([FromBody] SignatureRequest request)
    {
        try
        {
            var signature = _signatureRepository.Create(request);
            return Created($"api/signature/{signature.Id}", signature);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/signature/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_signatureRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
}