using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemOrderController : ControllerBase
{
    private readonly IItemOrderRepository _itemOrderRepository;

    public ItemOrderController(IItemOrderRepository itemOrderRepository)
    {
        _itemOrderRepository = itemOrderRepository;
    }

    // GET api/itemorder
    [HttpGet]
    public IActionResult GetAll()
    {
        var items = _itemOrderRepository.GetAll();
        return Ok(items);
    }

    // GET api/itemorder/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var item = _itemOrderRepository.GetById(id);
        if (item is null)
            return NotFound();
        return Ok(item);
    }

    // GET api/itemorder/order/{orderId}
    [HttpGet("order/{orderId:guid}")]
    public IActionResult GetByOrderId(Guid orderId)
    {
        var items = _itemOrderRepository.GetByOrderId(orderId);
        return Ok(items);
    }

    // POST api/itemorder
    [HttpPost]
    public IActionResult Create([FromBody] ItemOrderRequest request)
    {
        try
        {
            var item = _itemOrderRepository.Create(request);
            return Created($"api/itemorder/{item.Id}", item);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/itemorder/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_itemOrderRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
}