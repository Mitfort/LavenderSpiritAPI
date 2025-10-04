using System.Diagnostics.CodeAnalysis;

namespace LavenderSpiritAPI.Models
{
    public class Event
    {
        public Guid EventID { get; set; }

        public string EventName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Localization { get; set; }



        public DateTime DateTime { get; set; }
        public DateTime CreationDate { get; set; }


        // Owner ID
        public Guid OwnerID { get; set; }
        public virtual Voluntree Owner { get; set; }
    }
}
