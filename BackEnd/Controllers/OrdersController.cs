using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _ordersService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var order = _ordersService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            _ordersService.Create(order);
            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            _ordersService.Update(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ordersService.Delete(id);
            return NoContent();
        }
    }
}
