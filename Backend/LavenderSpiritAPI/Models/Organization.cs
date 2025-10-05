namespace LavenderSpiritAPI.Models
{
    public class Organization
    {
        public Guid OrgID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Description { get; set; }

        public virtual IEnumerable<LavEvent> HostedEvents { get; set; }
    }
}
