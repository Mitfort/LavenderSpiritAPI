using System.Threading.Tasks;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Services;

namespace LavenderSpiritAPI.Services
{
    public interface IOrganizationService
    {
        Task<bool> OrganizationExistsAsync(string email);
        Task<RegistrationResult> RegisterAsync(CreateOrganizationDTO registrationDto);
    }
}