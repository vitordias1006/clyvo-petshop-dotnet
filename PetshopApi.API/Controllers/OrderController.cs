using Microsoft.AspNetCore.Mvc;
using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;

namespace PetshopApi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    // GET api/order
    [HttpGet]
    public IActionResult GetAll()
    {
        var orders = _orderRepository.GetAll();
        return Ok(orders);
    }

    // GET api/order/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var order = _orderRepository.GetById(id);
        if (order is null)
            return NotFound();
        return Ok(order);
    }

    // GET api/order/user/{userId}
    [HttpGet("user/{userId:guid}")]
    public IActionResult GetByUserId(Guid userId)
    {
        var orders = _orderRepository.GetByUserId(userId);
        return Ok(orders);
    }

    // GET api/order/status/{status}
    [HttpGet("status/{status}")]
    public IActionResult GetByStatus(string status)
    {
        var orders = _orderRepository.GetByStatus(status);
        return Ok(orders);
    }

    // POST api/order
    [HttpPost]
    public IActionResult Create([FromBody] OrderRequest request)
    {
        try
        {
            var order = _orderRepository.Create(request);
            return Created($"api/order/{order.Id}", order);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE api/order/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_orderRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
}