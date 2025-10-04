using AutoMapper;
using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LavenderSpiritAPI.Services
{
    public class VolunteerService : IVolunteerService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<Voluntree> _passwordHasher;

        public VolunteerService(AppDbContext dbContext, IMapper _mapper, IPasswordHasher<Voluntree> passwordHasher)
        {
            _dbContext = dbContext;
            mapper = _mapper;
            _passwordHasher = passwordHasher;
        }

        public Guid CreateVolunteer(CreateVoluntreeDTO dTO)
        {
            Voluntree newVoluntree = mapper.Map<Voluntree>(dTO);
            newVoluntree.VoluntreeID = new Guid();

            newVoluntree.Password = _passwordHasher.HashPassword(newVoluntree, dTO.Password);

            _dbContext.Voluntrees.Add(newVoluntree);
            _dbContext.SaveChanges();
            return newVoluntree.VoluntreeID;
        }
    }
}
