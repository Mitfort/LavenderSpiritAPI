namespace LavenderSpiritAPI.Models
{
    public class Person : User
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
