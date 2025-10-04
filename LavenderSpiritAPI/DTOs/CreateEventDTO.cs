namespace LavenderSpiritAPI.DTOs
{
    public class CreateEventDTO
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }


        public DateTime DateTime { get; set; }
    }
}