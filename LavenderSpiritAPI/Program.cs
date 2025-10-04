
using AutoMapper;
using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Identity;
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
                cfg.CreateMap<CreateVoluntreeDTO, Voluntree>();
            });

            builder.Services.AddTransient<IVolunteerService, VolunteerService>();

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
