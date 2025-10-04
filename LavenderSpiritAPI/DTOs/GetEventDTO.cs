namespace LavenderSpiritAPI.DTOs
{
    public class GetEventDTO
    {
        public Guid EventID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }


        public DateTime DateTime { get; set; }
        public DateTime CreationDate { get; set; }

        public Guid OwnerID { get; set; }
    }
}
