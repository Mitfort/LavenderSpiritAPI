using LavenderSpiritAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public EventController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
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
    }
}
