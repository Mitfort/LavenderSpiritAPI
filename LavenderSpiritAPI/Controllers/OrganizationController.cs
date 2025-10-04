using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationService _organizationService;
        public OrganizationController(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization([FromBody] CreateOrganizationDTO organizationDTO)
        {
            var result = await _organizationService.RegisterAsync(organizationDTO);

            return result switch
            {
                RegistrationResult.Success => Ok(),
                RegistrationResult.EmailAlreadyExists => Conflict("Email already exists."),
                _ => BadRequest("Registration failed.")
            };
        }

        [HttpGet]
        public ActionResult GetAllOrganizations()
        {
            //TODO : Organization Service
            return Ok();
        }

        [HttpGet("{organizationID}")]
        public ActionResult GetOrganizationEvents(Guid organizationID)
        {
            //TODO : Organization Service
            return Ok();
        }


    }
}
