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
#nullable enable

        public DateTime DateTime { get; set; }
        public DateTime CreationDate { get; set; }


    }
}
