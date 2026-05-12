using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicalFileController : ControllerBase
{
    private readonly IMedicalFileRepository _medicalFileRepository;

    public MedicalFileController(IMedicalFileRepository medicalFileRepository)
    {
        _medicalFileRepository = medicalFileRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var medicalFiles = _medicalFileRepository.GetAll();
        return Ok(medicalFiles);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var medicalFile = _medicalFileRepository.GetById(id);
        if (medicalFile is null)
            return NotFound();
        return Ok(medicalFile);
    }

    [HttpGet("pet/{petId:guid}")]
    public IActionResult GetByPetId(Guid petId)
    {
        var medicalFile = _medicalFileRepository.GetByPetId(petId);
        if (medicalFile is null)
            return NotFound();
        return Ok(medicalFile);
    }

    [HttpPost]
    public IActionResult Create([FromBody] MedicalFileRequest request)
    {
        try
        {
            var medicalFile = _medicalFileRepository.Create(request);
            return Created($"api/medicalfile/{medicalFile.Id}", medicalFile);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_medicalFileRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] MedicalFileRequest request)
    {
        try
        {
            var medicalFile = _medicalFileRepository.Update(id, request);
            return Ok(medicalFile);
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