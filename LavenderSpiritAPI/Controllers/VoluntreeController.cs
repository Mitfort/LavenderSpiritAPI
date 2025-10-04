using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoluntreeController: ControllerBase
    {
        private readonly IVolunteerService _volunteerService;
        public VoluntreeController(IVolunteerService volunteerService) 
        { 
            _volunteerService = volunteerService;
        }


        // TO DO:
        //  Weryfikacja czy dane są poprawne
        [HttpPost]
        public IActionResult CreateVoluntre([FromBody]CreateVolunteerDTO dTO)
        {
            if (_volunteerService.IsEmailInDB(dTO.Email))
                return BadRequest();

            _volunteerService.CreateVolunteer(dTO);
            return Ok();
        }
    }
}
