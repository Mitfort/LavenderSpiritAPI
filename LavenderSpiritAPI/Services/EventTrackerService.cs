using AutoMapper;
using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LavenderSpiritAPI.Services
{
    public class EventTrackerService : IEventTrackerService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public EventTrackerService(AppDbContext _dbContext) 
        {
            dbContext = _dbContext;
        }

        public bool IsUserSubscribeEvent(Guid userId, Guid evenId)
        {
            var userEventD = dbContext.EventUsers
                .FirstOrDefault(eu => eu.VolunteerId == userId && eu.EventId == evenId);

            if (!(userEventD is null))
                return true;
            return false; // Becouse user do not subscribe
        }

        public void SubscribeEvent(Guid userId, Guid eventId)
        {
            var newEventUser = new EventUser();
            newEventUser.EventId = eventId;
            newEventUser.VolunteerId = userId;
            newEventUser.JoinedAt = DateTime.UtcNow;

            dbContext.EventUsers.Add(newEventUser);
            dbContext.SaveChanges();
        }

        public void UnSubscribeEvent(Guid userId, Guid eventId)
        {
            var eventUserToDelete = dbContext.EventUsers
                .FirstOrDefault(eu => eu.VolunteerId == userId && eu.EventId == eventId);

            dbContext.Remove(eventUserToDelete);
            dbContext.SaveChanges();
        }

        // Czy wyświetla wszystkie eventy danego user
        public IEnumerable<GetEventDTO> GetUsersEvents(Guid userId)
        {
            var userWithEvents = dbContext.Voluntrees
                .Include(e => e.EventUsers)
                    .ThenInclude(eu => eu.Event)
                    .FirstOrDefault(u => u.VoluntreeID == userId);

            if(userWithEvents is null)
                throw new Exception(); // There no such a user

            var events = userWithEvents.EventUsers.Select(eu => eu.Event).ToList();

            if (events.Count() == 0)
                throw new Exception(); // User has no events

            return mapper.Map<IEnumerable<GetEventDTO>>(events);
        }
    }
}
