using LavenderSpiritAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public OrganizationController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationById(int id)
        {
            var organization = await _dbContext.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }
            return Ok(organization);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization([FromBody] DTOs.OrganizationDTO newOrganizationDTO)
        {
            var newOrganization = new Models.Organization
            {
                Name = newOrganizationDTO.OrganizationName,
                CreationDate = DateTime.Now
            };

            _dbContext.Organizations.Add(newOrganization);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
