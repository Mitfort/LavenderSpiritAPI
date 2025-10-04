using LavenderSpiritAPI.Models;

namespace LavenderSpiritAPI.Services
{
    public interface IAuthService
    {
        string GenerateJwt(Voluntree user);
    }
}
