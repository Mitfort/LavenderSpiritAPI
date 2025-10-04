using AutoMapper;
using LavenderSpiritAPI.Data;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LavenderSpiritAPI.Services
{
    public class VolunteerService : IVolunteerService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper mapper;

        public VolunteerService(AppDbContext dbContext, IMapper _mapper)
        {
            _dbContext = dbContext;
            mapper = _mapper;
        }

        public Guid CreateVolunteer(CreateVoluntreeDTO dTO)
        {
            Voluntree newVoluntree = mapper.Map<Voluntree>(dTO);
            newVoluntree.VoluntreeID = new Guid();

            _dbContext.Voluntrees.Add(newVoluntree);
            _dbContext.SaveChanges();
            return newVoluntree.VoluntreeID;
        }
    }
}
