using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;

namespace LavenderSpiritAPI.Services
{
    public interface IVolunteerService
    {
        public Guid CreateVolunteer(CreateVoluntreeDTO dTO);
        public Voluntree? Login(LoginDTO dTO);
    }
}
