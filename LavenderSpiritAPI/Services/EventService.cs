using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.Data;

namespace LavenderSpiritAPI.Services
{
    public class EventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Event> DodajEventAsync(Event nowyEvent)
        {
            nowyEvent.CreationDate = DateTime.UtcNow;

            _context.Events.Add(nowyEvent);
            await _context.SaveChangesAsync();

            return nowyEvent;
        }

        public async Task<Event?> EdytujEventAsync(int id, Event zaktualizowanyEvent, int organizatorId)
        {
            var istniejącyEvent = await _context.Events.FindAsync(id);
            if (istniejącyEvent == null) return null;

            if (istniejącyEvent.OrganizatorID != organizatorId)
                throw new UnauthorizedAccessException("Nie możesz edytować tego wydarzenia.");

            // aktualizacja pól
            istniejącyEvent.EventName = zaktualizowanyEvent.EventName;
            istniejącyEvent.Description = zaktualizowanyEvent.Description;
            istniejącyEvent.DateTime = zaktualizowanyEvent.DateTime;
            istniejącyEvent.Localization = zaktualizowanyEvent.Localization;

            await _context.SaveChangesAsync();
            return istniejącyEvent;
        }


        public async Task<bool> UsunEventAsync(int id, int organizatorId)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return false;
            if (ev.OrganizatorID != organizatorId)
                throw new UnauthorizedAccessException("Nie możesz edytować tego wydarzenia.");

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<Event?> PobierzEventPoIdAsync(Guid id)
        {//event po id
            return await _context.Events
                .Include(e => e.EventName)
                .Include(e => e.OrganizatorID)
                .FirstOrDefaultAsync(e => e.EventID == id);
        }

        public async Task<List<Event>> PobierzEventyPoIdOrganizacjiAsync(int organizacjaId)
        {
            return await _context.Events
                .Where(e => e.OrganizatorID == organizacjaId)
                .Include(e => e.EventName) //eventname
                .ToListAsync();
        }

        public async Task<List<Event>> PobierzWszystkieEventyAsync()
        {
            return await _context.Events
                .Include(e => e.EventName) //eventname
                .Include(e => e.OrganizatorID)
                .OrderByDescending(e => e.DateTime)
                .ToListAsync();
        }


    }
}
//controler to eventow
//validacja czy ktos jest organizatorem czy moze usunac lub edytowac