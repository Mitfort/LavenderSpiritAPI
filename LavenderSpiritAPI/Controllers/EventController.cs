using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            var events = await _eventService.PobierzWszystkieEventyAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(Guid id)
        {
            var ev = await _eventService.PobierzEventPoIdAsync(id);
            if (ev == null)
                return NotFound(new { message = "Event not found." });

            return Ok(ev);
        }

        [HttpGet("organization/{organizationId}")]
        public async Task<ActionResult<List<Event>>> GetEventsByOrganization(int organizationId)
        {
            var events = await _eventService.PobierzEventyPoIdOrganizacjiAsync(organizationId);
            return Ok(events);
        }
            return Ok(evnt);
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] Event newEvent)
        {
            if (newEvent == null)
                return BadRequest(new { message = "Invalid event data." });

            var created = await _eventService.DodajEventAsync(newEvent);
            return CreatedAtAction(nameof(GetEventById), new { id = created.EventID }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEvent(int id, [FromBody] Event updatedEvent)
        {
            if (updatedEvent == null)
                return BadRequest(new { message = "Invalid event data." });

            if (updatedEvent.OrganizatorID != GetCurrentUserId())
                return Forbid("You are not allowed to edit this event.");

            var result = await _eventService.EdytujEventAsync(id, updatedEvent, GetCurrentUserId());
            if (result == null)
                return NotFound(new { message = "Event not found." });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id, [FromQuery] int organizerId)
        {
            if (organizerId != GetCurrentUserId())
                return Forbid("You are not allowed to delete this event.");

            var success = await _eventService.UsunEventAsync(id, organizerId);
            if (!success)
                return NotFound(new { message = "Event not found." });

            return NoContent();
        }

        private int GetCurrentUserId()
        {
            return 1;
        }
    }
}
