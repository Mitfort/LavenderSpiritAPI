namespace LavenderSpiritAPI.Models
{
    public class EventOrganization
    {
        public Guid EventID;
        public LavEvent Event;

        public Guid OrganizationID;
        public Organization Organization;
    }
}
