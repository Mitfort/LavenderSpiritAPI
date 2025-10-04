using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private VolunteerService _volunteerService;
        public EventController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._volunteerService = new VolunteerService(dbContext, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var evnt = await _dbContext.Events.FindAsync(id);
            if (evnt == null)
            {
                return NotFound();
            }
            return Ok(evnt);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] DTOs.EventDTO newEventDTO)
        {
            var newEvent = new Models.Event
            {
                EventID = new Guid(),
                EventName = newEventDTO.EventName,
                DateTime = newEventDTO.StartDate,
                CreationDate = DateTime.Now,
                Description = "Description placeholder",
                Status = "Scheduled",
                Localization = "Localization placeholder",
                OwnerID = 1 // Placeholder for OwnerID, should be set based on authenticated user
            };
            


            return Ok();
        }
    }
}
