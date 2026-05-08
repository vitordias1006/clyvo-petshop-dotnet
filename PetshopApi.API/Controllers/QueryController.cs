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

    // GET api/query
    [HttpGet]
    public IActionResult GetAll()
    {
        var queries = _queryRepository.GetAll();
        return Ok(queries);
    }

    // GET api/query/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var query = _queryRepository.GetById(id);
        if (query is null)
            return NotFound();
        return Ok(query);
    }

    // GET api/query/pet/{petId}
    [HttpGet("pet/{petId:guid}")]
    public IActionResult GetByPetId(Guid petId)
    {
        var queries = _queryRepository.GetByPetId(petId);
        return Ok(queries);
    }

    // GET api/query/status/{status}
    [HttpGet("status/{status}")]
    public IActionResult GetByStatus(string status)
    {
        var queries = _queryRepository.GetByStatus(status);
        return Ok(queries);
    }

    // POST api/query
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

    // DELETE api/query/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_queryRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
}