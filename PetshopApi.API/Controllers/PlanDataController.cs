using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanDataController : ControllerBase
{
    private readonly IPlanDataRepository _planDataRepository;

    public PlanDataController(IPlanDataRepository planDataRepository)
    {
        _planDataRepository = planDataRepository;
    }

    // GET api/plandata
    [HttpGet]
    public IActionResult GetAll()
    {
        var plans = _planDataRepository.GetAll();
        return Ok(plans);
    }

    // GET api/plandata/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var plan = _planDataRepository.GetById(id);
        if (plan is null)
            return NotFound();
        return Ok(plan);
    }

    // GET api/plandata/signature/{signatureId}
    [HttpGet("signature/{signatureId:guid}")]
    public IActionResult GetBySignatureId(Guid signatureId)
    {
        var plans = _planDataRepository.GetBySignatureId(signatureId);
        return Ok(plans);
    }

    // GET api/plandata/active
    [HttpGet("active")]
    public IActionResult GetActive()
    {
        var plans = _planDataRepository.GetActive();
        return Ok(plans);
    }

    // POST api/plandata
    [HttpPost]
    public IActionResult Create([FromBody] PlanDataRequest request)
    {
        try
        {
            var plan = _planDataRepository.Create(request);
            return Created($"api/plandata/{plan.Id}", plan);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/plandata/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_planDataRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
}