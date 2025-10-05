using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LavenderSpiritAPI.Models
{
    public class LavEvent
    {
        public Guid EventID { get; set; }

        public string EventName { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }



        public DateTime DateTime { get; set; }
        public DateTime CreationDate { get; set; }


        // Owner ID
        public Guid OrgID { get; set; }
        public virtual Organization Org { get; set; }

        public ICollection<EventUser> EventUsers { get; set; }
    }
}
