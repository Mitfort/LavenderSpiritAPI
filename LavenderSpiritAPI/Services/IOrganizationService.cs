using System.Threading.Tasks;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;

namespace LavenderSpiritAPI.Services
{
    public interface IOrganizationService
    {
        Task<bool> OrganizationExistsAsync(string email);
        Task<RegistrationResult> RegisterAsync(CreateOrganizationDTO registrationDto);
    }
}