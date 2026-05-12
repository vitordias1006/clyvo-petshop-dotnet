using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QueryController : ControllerBase
{
    private readonly IQueryRepository _queryRepository;

    public QueryController(IQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var queries = _queryRepository.GetAll();
        return Ok(queries);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var query = _queryRepository.GetById(id);
        if (query is null)
            return NotFound();
        return Ok(query);
    }

    [HttpGet("pet/{petId:guid}")]
    public IActionResult GetByPetId(Guid petId)
    {
        var queries = _queryRepository.GetByPetId(petId);
        return Ok(queries);
    }

    [HttpGet("status/{status}")]
    public IActionResult GetByStatus(string status)
    {
        var queries = _queryRepository.GetByStatus(status);
        return Ok(queries);
    }

    [HttpPost]
    public IActionResult Create([FromBody] QueryRequest request)
    {
        try
        {
            var query = _queryRepository.Create(request);
            return Created($"api/query/{query.Id}", query);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_queryRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] QueryRequest request)
    {
        try
        {
            var query = _queryRepository.Update(id, request);
            return Ok(query);
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