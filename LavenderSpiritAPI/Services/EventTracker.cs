using LavenderSpiritAPI.Data;

namespace LavenderSpiritAPI.Services
{
    public class EventTracker
    {
        private readonly AppDbContext dbContext;

        public EventTracker(AppDbContext _dbContext) 
        {
            dbContext = _dbContext;
        }


    }
}
