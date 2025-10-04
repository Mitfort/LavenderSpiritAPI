using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    public class EventTrackerController : ControllerBase
    {
        private readonly IEventTrackerService eventTrackerService;

        public EventTrackerController(IEventTrackerService _eventTrackerService)
        {
            eventTrackerService = _eventTrackerService;
        }

        public ActionResult GetEventVolontrees()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult SubscribeEvent(Guid userId, Guid eventId)
        {
            if(!eventTrackerService.IsUserSubscribeEvent(userId,eventId))
                return BadRequest(); // Add sth

            eventTrackerService.SubscribeEvent(userId,eventId);
            return Ok();
        }

        [HttpDelete]
        public ActionResult UnSubscribeEvent(Guid userId, Guid eventId)
        {
            if(eventTrackerService.IsUserSubscribeEvent(userId, eventId))
                return BadRequest(); // Add sth

            eventTrackerService.UnSubscribeEvent(userId,eventId);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetEventDTO>> GetUsersEvents(Guid userId)
        {
            return Ok(eventTrackerService.GetUsersEvents(userId));
        }
    }
}
