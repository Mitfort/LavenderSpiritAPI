using System.ComponentModel.DataAnnotations;

namespace LavenderSpiritAPI.DTOs
{
    public class CreateEventDTO
    {
        [Required(ErrorMessage = "Nazwa eventu jest wymagana.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nazwa eventu musi mieć od 3 do 100 znaków.")]
        public string EventName { get; set; }

        [StringLength(500, ErrorMessage = "Opis może mieć maksymalnie 500 znaków.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Lokalizacja eventu jest wymagana.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Lokalizacja musi mieć od 5 do 200 znaków.")] 
        public string Localization { get; set; }

        [Required(ErrorMessage = "Data i czas eventu są wymagane.")] 
       // [FutureDate(ErrorMessage = "Data i czas eventu muszą być w przyszłości.")]
        public DateTime DateTime { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.Now;
            }
            return false;
        }
    }

}