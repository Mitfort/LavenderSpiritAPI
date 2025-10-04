using System.Diagnostics.CodeAnalysis;

namespace LavenderSpiritAPI.Models
{
    public class Event
    {
        [NotNull]
        public Guid EventID { get; set; }

#nullable disable
        [NotNull]
        public string EventName { get; set; }

        [NotNull]
        public string Description { get; set; }

        [NotNull]
        public string PhotoPath { get; set; }

        [NotNull]
        public string Status { get; set; }

        [NotNull]
        public string Localization { get; set; }

        public string AdditionalInformations { get; set; }
#nullable enable

        public DateTime DateTime { get; set; }
        public DateTime CreationDate { get; set; }



        public int UserID { get; set; }
        // public virtual User User;
    }
}
