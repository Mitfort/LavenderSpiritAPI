using LavenderSpiritAPI.DTOs;

namespace LavenderSpiritAPI.Services
{
    public interface IEventService
    {
        public Guid CreateEvent(Guid userId, CreateEventDTO dTO);
        public void DeleteEvent(Guid userId, Guid eventId);
    }
}
