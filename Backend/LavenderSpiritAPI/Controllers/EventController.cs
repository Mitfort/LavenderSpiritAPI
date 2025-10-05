using Microsoft.AspNetCore.Authorization;
using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService volunteerService)
        {
            _eventService = volunteerService;
        }

        [HttpPost("{userID}")]
        public IActionResult CreateEvent(Guid userID, [FromBody]CreateEventDTO eventDTO)
        {
            _eventService.CreateEvent(userID, eventDTO);

            return Ok();
        }

        [HttpDelete("{userID}/{eventID}")]
        public IActionResult DeleteEvent(Guid userID, Guid eventID)
        {
            _eventService.DeleteEvent(userID, eventID);
            return Ok();
        }

        [HttpGet("{eventID}")]
        public ActionResult<GetEventDTO> GetEventById(Guid eventID)
        {
            var eventDTO = _eventService.GetEventById(eventID);
            return Ok(eventDTO);
        }

        [HttpGet]
        public ActionResult<ICollection<GetEventDTO>> GetEvents()
        {
            var events = _eventService.GetEvents();
            return Ok(events);
        }

    }
}
