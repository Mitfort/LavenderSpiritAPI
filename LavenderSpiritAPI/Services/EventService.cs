using AutoMapper;
using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Exceptions;
using LavenderSpiritAPI.Models;

namespace LavenderSpiritAPI.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public EventService(AppDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public Guid CreateEvent(Guid userId, CreateEventDTO dTO)
        {
            var newEvent = mapper.Map<LavEvent>(dTO);
            newEvent.OwnerID = userId;
            newEvent.CreationDate = DateTime.UtcNow;
            newEvent.EventID = new Guid();

            dbContext.Events.Add(newEvent);
            dbContext.SaveChanges();

            return newEvent.EventID;
        }

        public void DeleteEvent(Guid userId, Guid eventId)
        {
            var eventToDelete = dbContext.Events.FirstOrDefault(e => e.EventID == eventId);

            if (eventToDelete is null)
                throw new EventNotFoundException($"Event nie istnieje.");

            if (eventToDelete.OwnerID != userId)
                throw new UnauthorizedEventAccessException($"Użytkownik {userId} nie jest właścicielem tego wydarzenia.");


            dbContext.Events.Remove(eventToDelete);
            dbContext.SaveChanges();
        }

        public GetEventDTO GetEventById(Guid eventId)
        {
            var gEvent = dbContext.Events.FirstOrDefault(e => e.EventID == eventId);
            return mapper.Map<GetEventDTO>(gEvent);
        }

        public ICollection<GetEventDTO> GetEvents ()
        {
            var gEvents = dbContext.Events.ToList();
            return mapper.Map<ICollection<GetEventDTO>>(gEvents);
        }
    }
}
