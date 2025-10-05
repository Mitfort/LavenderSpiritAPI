using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;

namespace LavenderSpiritAPI.Services
{
    public interface IAuthService
    {
        public string Login(LoginDTO dto);
    }
}
