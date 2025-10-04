using LavenderSpiritAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LavenderSpiritAPI.Services
{
    public class VolounteerService
    {
        private readonly AppDbContext _dbContext;

        public VolounteerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void CrateEvent(Models.Event newEvent)
        {
            // Implementation for creating an event
            _dbContext.Events.Add(newEvent);
            await _dbContext.SaveChangesAsync();
        }
    }
}
