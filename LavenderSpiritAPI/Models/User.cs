using System.Diagnostics.CodeAnalysis;

namespace LavenderSpiritAPI.Models
{
    public class User
    {
        public Guid UserID { get; set; } = Guid.NewGuid();
        [NotNull]
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; } 

    }
}
