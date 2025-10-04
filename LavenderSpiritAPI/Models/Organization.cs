using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace LavenderSpiritAPI.Models
{
    public class Organization
    {
        public Guid OrganizationID { get; set; }
        [Required]
        public string Name { get; set; }
        public User Creator { get; set; }
        public DateTime CreationDate { get; set; }
        public List<User> Members { get; set; } = new List<User>();
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
