using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;

namespace LavenderSpiritAPI.Services
{
    public interface IVolunteerService
    {
        public bool IsEmailInDB(string email);
        public Guid CreateVolunteer(CreateVolunteerDTO dTO);
        public Guid CreateVolunteer(CreateVoluntreeDTO dTO);
        public Voluntree? Login(LoginDTO dTO);
    }
}
