using System.ComponentModel.DataAnnotations;

namespace LavenderSpiritAPI.DTOs
{
    public class CreateOrganizationDTO
    {
        [Required(ErrorMessage = "Adres email jest wymagany.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nazwa organizacji jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa organizacji nie może przekraczać 100 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$",
            ErrorMessage = "Hasło musi mieć co najmniej 8 znaków i zawierać: cyfrę, małą i wielką literę oraz znak specjalny.")]
        public string Password { get; set; }
    
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
    }

}
