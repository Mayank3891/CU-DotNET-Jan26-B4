using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController(IDestinationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestinations()
        {
            var destinations = await _service.GetAllAsync();
            return Ok(destinations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Destination>> GetDestination(int id)
        {
            var destination = await _service.GetByIdAsync(id);
            if (destination == null)
                return NotFound();

            return Ok(destination);
        }

        [HttpPost]
        public async Task<ActionResult<Destination>> PostDestination(Destination destination)
        {
            await _service.AddAsync(destination);
            return CreatedAtAction(nameof(GetDestination), new { id = destination.Id }, destination);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestination(int id, Destination destination)
        {
            destination.Id = id; // enforce route Id
            await _service.UpdateAsync(destination);
            return NoContent(); // or return Ok(destination) if you want the updated object
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}