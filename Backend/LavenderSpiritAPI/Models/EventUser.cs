namespace LavenderSpiritAPI.Models
{
    public class EventUser
    {
        public Guid VolunteerId { get; set; }
        public Voluntree Voluntree { get; set; }

        public Guid EventId { get; set; }
        public LavEvent Event { get; set; }

        // Additional Fields
        public DateTime JoinedAt { get; set; }

    }
}
