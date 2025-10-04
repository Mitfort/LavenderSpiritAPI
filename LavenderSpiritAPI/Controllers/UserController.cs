using LavenderSpiritAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace LavenderSpiritAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] DTOs.UserDTO newUserDTO)
        {
            var newUser = new Models.User
            {
                RoleID = 0,
                Email = newUserDTO.Email,
                Password = newUserDTO.Password,
                Username = newUserDTO.FirstName + " " + newUserDTO.LastName,
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
