using AutoMapper;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace LavenderSpiritAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Data.AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            builder.Services.AddControllers();

            // Add AutoMapper
            builder.Services.AddAutoMapper(cfg => 
            {
                cfg.CreateMap<CreateVolunteerDTO, Voluntree>();
                cfg.CreateMap<CreateEventDTO, LavEvent>();
                cfg.CreateMap<LavEvent, GetEventDTO>();
            });

            builder.Services.AddScoped<IVolunteerService, VolunteerService>();
            builder.Services.AddScoped<IEventTrackerService, EventTrackerService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
