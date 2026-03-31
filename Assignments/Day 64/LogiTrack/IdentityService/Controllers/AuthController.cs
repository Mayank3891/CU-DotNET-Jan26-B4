using IdentityService.DTO;
using IdentityService.DTOs.RegisterDto;
using LogiTrack.Identity.Service;
using Microsoft.AspNetCore.Mvc;

namespace LogiTrack.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly TokenService _tokenService;

        // In-memory user store for demo
        private static readonly List<RegisterDto> _users = new()
        {
            new RegisterDto { Email = "manager@test.com", Password = "Password123", Role = "Manager" },
            new RegisterDto { Email = "driver@test.com", Password = "Password123", Role = "Driver" }
        };

        public IdentityController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _users.FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = _tokenService.GenerateToken(user.Email, user.Role);
            return Ok(new { access_token = token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            if (_users.Any(u => u.Email == registerDto.Email))
                return BadRequest("User already exists");

            _users.Add(registerDto);
            return Ok("User registered successfully");
        }
    }
}