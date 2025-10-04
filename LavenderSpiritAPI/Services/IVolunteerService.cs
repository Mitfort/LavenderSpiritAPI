using LavenderSpiritAPI.DTOs;

namespace LavenderSpiritAPI.Services
{
    public interface IVolunteerService
    {
        public bool IsEmailInDB(string email);
        public Guid CreateVolunteer(CreateVolunteerDTO dTO);
    }
}
