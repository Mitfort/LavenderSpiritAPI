using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly VolounteerService _volounteerService;
        public EventController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            _volounteerService = new VolounteerService(dbContext);
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

        [HttpPost("{userID}")]
        public async Task<IActionResult> CreateEvent(Guid userID, [FromBody] DTOs.EventDTO newEventDTO)
        {
            var owner = await _dbContext.Voluntrees.FindAsync(userID);


            var newEvent = new Models.Event
            {
                EventID = new Guid(),
                EventName = newEventDTO.EventName,
                CreationDate = DateTime.Now,
                Localization = newEventDTO.Location,
                Status = "Open",
                DateTime = newEventDTO.StartDate,
                Description = $"Event from {newEventDTO.StartDate} to {newEventDTO.EndDate}",
                OwnerID = userID // Temporary, should be replaced with actual user ID from authentication
            };

            _volounteerService.CrateEvent(newEvent);

            return Ok();
        }
    }
}
