using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    public class EventTrackerController : ControllerBase
    {
        public ActionResult GetEventVolontrees(int eventId)
        {
            return Ok();
        }

        public ActionResult SubscribeEvent(int volontreeId, int eventId)
        {
            return Ok();
        }

        public ActionResult UnSubscribeEvent(int volontreeId, int eventId)
        {
            return Ok();
        }
    }
}
