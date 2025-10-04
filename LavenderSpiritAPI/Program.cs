using AutoMapper;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LavenderSpiritAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] conStr = {
                "DefaultConnectionString",
                "DefaultConnectionStringQbus"
            };
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Data.AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString(conStr[0])));

            builder.Services.AddControllers();

            // Add AutoMapper
            builder.Services.AddAutoMapper(cfg => 
            {
                cfg.CreateMap<CreateVolunteerDTO, Voluntree>();
                cfg.CreateMap<CreateEventDTO, LavEvent>();
                cfg.CreateMap<LavEvent, GetEventDTO>();
                //cfg.CreateMap<IEnumerable<LavEvent>, IEnumerable<GetEventDTO>>();
            });

            builder.Services.AddScoped<IVolunteerService, VolunteerService>();
            builder.Services.AddScoped<LavenderSpiritAPI.Services.IEventService, LavenderSpiritAPI.Services.EventService>();
            builder.Services.AddScoped<IEventTrackerService, EventTrackerService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPasswordHasher<Voluntree>, PasswordHasher<Voluntree>>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
