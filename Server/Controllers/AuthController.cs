// Server/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorDentista.Server.Data;
using BlazorDentista.Server.Dtos;
using BlazorDentista.Server.Models;
using BCrypt.Net;

namespace BlazorDentista.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
                return BadRequest("User already exists.");

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return BadRequest("Invalid credentials.");

            // Generate token logic here (e.g., JWT)
            return Ok("Login successful.");
        }
    }
}
