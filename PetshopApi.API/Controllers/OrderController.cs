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

    [HttpGet]
    public IActionResult GetAll()
    {
        var orders = _orderRepository.GetAll();
        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var order = _orderRepository.GetById(id);
        if (order is null)
            return NotFound();
        return Ok(order);
    }

    [HttpGet("user/{userId:guid}")]
    public IActionResult GetByUserId(Guid userId)
    {
        var orders = _orderRepository.GetByUserId(userId);
        return Ok(orders);
    }

    [HttpGet("status/{status}")]
    public IActionResult GetByStatus(string status)
    {
        var orders = _orderRepository.GetByStatus(status);
        return Ok(orders);
    }

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

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_orderRepository.Delete(id))
            return NotFound();
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] OrderRequest request)
    {
        try
        {
            var order = _orderRepository.Update(id, request);
            return Ok(order);
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