using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventTrackerController : ControllerBase
    {
        private readonly IEventTrackerService eventTrackerService;

        public EventTrackerController(IEventTrackerService _eventTrackerService)
        {
            eventTrackerService = _eventTrackerService;
        }

        [HttpPost("{userId}/{eventId}")]
        public ActionResult SubscribeEvent(Guid userId, Guid eventId)
        {
            if(eventTrackerService.IsUserSubscribeEvent(userId,eventId))
                return BadRequest("Użytkownik jest już zapisany na to wydarzenie."); 

            eventTrackerService.SubscribeEvent(userId,eventId);
            return Ok("Zapisano na wydarzenie.");
        }

        [HttpDelete("{userId}/{eventId}")]
        public ActionResult UnSubscribeEvent(Guid userId, Guid eventId)
        {
            if(!eventTrackerService.IsUserSubscribeEvent(userId, eventId))
                return BadRequest("Użytkownik nie jest zapisany na to wydarzenie."); 

            eventTrackerService.UnSubscribeEvent(userId,eventId);
            return Ok("Wypisano z wydarzenia.");
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<GetEventDTO>> GetUsersEvents(Guid userId)
        {
            return Ok(eventTrackerService.GetUsersEvents(userId));
        }
    }
}
