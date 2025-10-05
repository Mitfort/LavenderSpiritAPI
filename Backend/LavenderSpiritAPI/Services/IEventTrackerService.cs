using LavenderSpiritAPI.DTOs;

namespace LavenderSpiritAPI.Services
{
    public interface IEventTrackerService
    {
        public bool IsUserSubscribeEvent(Guid userId, Guid evenId);
        public void SubscribeEvent(Guid userId, Guid eventId);
        public void UnSubscribeEvent(Guid userId, Guid eventId);
        public IEnumerable<GetEventDTO> GetUsersEvents(Guid userId);
    }
}
