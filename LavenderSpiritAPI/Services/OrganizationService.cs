using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Data;

namespace LavenderSpiritAPI.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly AppDbContext _context;

    
        public OrganizationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> OrganizationExistsAsync(string email)
        {
          
            return await _context.Set<Organization>()
                                 .AnyAsync(o => o.Email.ToLower() == email.ToLower());
        }

        public async Task<RegistrationResult> RegisterAsync(CreateOrganizationDTO registrationDto)
        {
            if (registrationDto == null)
            {
                return RegistrationResult.Failure;
            }

            if (await OrganizationExistsAsync(registrationDto.Email))
            {
                return RegistrationResult.EmailAlreadyExists;
            }

            try
            {
                var organization = new Organization
                {
                    OrgID = Guid.NewGuid(),
                    Name = registrationDto.Name,
                    Email = registrationDto.Email,
                    Password = registrationDto.Password
                };

                _context.Set<Organization>().Add(organization);
                await _context.SaveChangesAsync();

                return RegistrationResult.Success;
            }
            catch (Exception ex)
            {
 
                return RegistrationResult.Failure;
            }
        }
    }
}