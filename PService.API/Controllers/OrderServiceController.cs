using System.Net;
using Microsoft.AspNetCore.Mvc;
using PsService.API;
using PsService.Domain;

namespace PService.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderServiceController : ControllerBase
{
  
    // private readonly ILogger<OrderServiceController> _logger;
    // private readonly IOrderServiceRepository _repository;

    // public OrderServiceController(
    //     ILogger<OrderServiceController> logger,
    //     IOrderServiceRepository repository
    // ){
    //     _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    //     _repository  = repository ?? throw new ArgumentNullException(nameof(repository));
    // }
    // [HttpPost]
    // [ProducesResponseType(typeof(OrderServiceResponse),(int)HttpStatusCode.Created)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // public async Task<IActionResult> CreateOrder([FromBody] OrderServiceRequest request){

    //     var order = new OrderService(request.CustomerId,request.ServiceName,request.ServiceDescription);

    //      _logger.LogInformation("----- Creating Order - Order: {@Order}", order);

    //     await _repository.Add(order);
    //     await _repository.UnitOfWork.SaveEntitiesAsync();

    //     return CreatedAtAction(nameof(GetOrderByIdAsync), new { id = order.Id }, null);
    // }
    // [HttpGet("{id}")]
    // [ProducesResponseType(typeof(OrderServiceResponse),(int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.NotFound)]

    // public async Task<ActionResult<OrderServiceResponse>> GetOrderByIdAsync(int id){

    //     var order = await _repository.GetOrderAsync(id);
    //     if(order is null) return NotFound();
    //     return Ok(OrderServiceResponse.FromOrderService(order));

    // }
    
}
