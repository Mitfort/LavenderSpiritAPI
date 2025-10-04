using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    public class VoluntreeController: ControllerBase
    {
        private readonly IVolunteerService _volunteerService;
        public VoluntreeController(IVolunteerService volunteerService) 
        { 
            _volunteerService = volunteerService;
        }

        [HttpPost]
        public IActionResult CreateVoluntre([FromBody]CreateVoluntreeDTO dTO)
        {
            _volunteerService.CreateVolunteer(dTO);
            return Ok();
        }
    }
}
