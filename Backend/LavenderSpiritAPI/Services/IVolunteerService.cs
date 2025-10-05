using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;

namespace LavenderSpiritAPI.Services
{
    public interface IVolunteerService
    {
        public bool IsEmailInDB(string email);
        public Guid RegisterVolunteer(CreateVolunteerDTO dTO);
    }
}
