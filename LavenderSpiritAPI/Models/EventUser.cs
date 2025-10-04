namespace LavenderSpiritAPI.Models
{
    public class EventUser
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int EventID { get; set; }
        public virtual Event Event { get; set; }


        public DateTime JoinedAt { get; set; }
        public string Status { get; set; }
    }
}
