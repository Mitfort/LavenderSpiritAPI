using System.Linq;
using System.Threading.Tasks;
using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LavenderSpiritAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;

        public AuthController(AppDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), 200)] 
        [ProducesResponseType(401)] 
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Voluntrees
                .FirstOrDefaultAsync(v => v.Email == dto.Email);

            if (user == null)
            {
                return Unauthorized(new { message = "Niepoprawny email lub has³o." });
            }

            if (user.Password != dto.Password)
            {
                return Unauthorized(new { message = "Niepoprawny email lub has³o." });
            }

            var token = _authService.GenerateJwt(user);

            return Ok(new { token = token });
        }
    }
}