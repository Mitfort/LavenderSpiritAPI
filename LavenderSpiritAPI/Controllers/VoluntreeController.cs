using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoluntreeController : ControllerBase
    {
        private readonly IVolunteerService _volunteerService;
        public VoluntreeController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        [HttpPost("register")]
        public IActionResult CreateVoluntre([FromBody] CreateVolunteerDTO dTO)
        {
            if (_volunteerService.IsEmailInDB(dTO.Email))
                return BadRequest();

            _volunteerService.CreateVolunteer(dTO);

            return Ok();
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var user = _volunteerService.Login(dto);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
