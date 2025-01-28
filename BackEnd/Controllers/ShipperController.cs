using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            var shippers = await _shipperService.GetAllAsync();
            return Ok(shippers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shipper = await _shipperService.GetByIdAsync(id);
            if (shipper == null) return NotFound();
            return Ok(shipper);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Shipper shipper)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _shipperService.AddAsync(shipper);
            return CreatedAtAction(nameof(GetById), new { id = shipper.ShipperId }, shipper);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Shipper shipper)
        {
            if (id != shipper.ShipperId) return BadRequest();
            await _shipperService.UpdateAsync(shipper);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shipperService.DeleteAsync(id);
            return NoContent();
        }
    }
}
