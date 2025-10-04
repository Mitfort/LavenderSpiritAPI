namespace LavenderSpiritAPI.Models
{
    public class Organization
    {
        public Guid OrganizationID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual IEnumerable<LavEvent> HostedEvents { get; set; } = new List<LavEvent>();
    }
}
