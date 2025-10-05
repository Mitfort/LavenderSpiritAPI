using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace LavenderSpiritAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly AppDbContext dbContext;
        private readonly IPasswordHasher<Voluntree> passwordHasher;

        public AuthService(AppDbContext _dbContext, AuthenticationSettings authenticationSettings)
        {
            dbContext = _dbContext;
            _authenticationSettings = authenticationSettings;
        }

        public string Login(LoginDTO dto)
        {
            var user = dbContext.Voluntrees.FirstOrDefault(v => v.Email == dto.Email);

            if (user is null)
                throw new Exception();

            var result = passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Unvalid Credentials");

            return generateJwt(user);
        }

        private string generateJwt(Voluntree voluntree)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, voluntree.VoluntreeID.ToString()),
                new Claim(ClaimTypes.Email, voluntree.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer, 
                claims,
                expires: expires,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}