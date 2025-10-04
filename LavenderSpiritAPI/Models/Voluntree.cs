namespace LavenderSpiritAPI.Models
{
    public class Voluntree
    {
        public Guid VoluntreeID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<EventUser> EventUsers { get; set; }
    }
}
