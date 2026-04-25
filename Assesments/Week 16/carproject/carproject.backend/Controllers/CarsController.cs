using CarManagement.Application.DTOs;

using carproject.backend.Service;
using carproject.backend.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace carproject.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<CarDto>>(data, "Cars fetched successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound(new ApiResponse<string>("Car not found"));

            return Ok(new ApiResponse<CarDto>(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarDto dto)
        {
            var data = await _service.CreateAsync(dto);
            return Ok(new ApiResponse<CarDto>(data, "Car created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCarDto dto)
        {
            var data = await _service.UpdateAsync(id, dto);
            return Ok(new ApiResponse<CarDto>(data, "Car updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound(new ApiResponse<string>("Car not found"));

            return Ok(new ApiResponse<string>("Car deleted successfully"));
        }
    }
}