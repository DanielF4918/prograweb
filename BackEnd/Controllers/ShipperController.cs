using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperService _shipperService;

        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet]
        public IEnumerable<Shipper> Get()
        {
            return _shipperService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Shipper> Get(int id)
        {
            var shipper = _shipperService.GetById(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return shipper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Shipper shipper)
        {
            _shipperService.Create(shipper);
            return CreatedAtAction(nameof(Get), new { id = shipper.ShipperId }, shipper);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Shipper shipper)
        {
            _shipperService.Update(shipper);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _shipperService.Delete(id);
            return NoContent();
        }
    }
}
