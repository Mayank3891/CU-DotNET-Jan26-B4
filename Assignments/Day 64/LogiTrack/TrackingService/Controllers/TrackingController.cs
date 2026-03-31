using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        [HttpGet("ForDrivers")]
        [Authorize(Roles ="Driver")]
        public IActionResult Driver()
        {
            return Ok("You are a driver");
        }
        [HttpGet("ForManagers")]
        [Authorize(Roles = "Manger")]
        public IActionResult Manager()
        {
            return Ok("You are a Manager");
        }
    }
}
