using LavenderSpiritAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        public OrganizationController()
        {

        }

        [HttpPost]
        public ActionResult CreateOrganization([FromBody] CreateOrganizationDTO organizationDTO)
        {
            //TODO : Organization Service

            return Ok();
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
