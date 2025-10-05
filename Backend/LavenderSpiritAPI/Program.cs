using LavenderSpiritAPI.DTOs;
using LavenderSpiritAPI.Models;
using LavenderSpiritAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer; 
using Microsoft.IdentityModel.Tokens; 
using System.Text; 
using System; 
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

            //authenticationSettings
            var authenticationSettings = new AuthenticationSettings();
            builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
            builder.Services.AddSingleton(authenticationSettings);

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "Bearer";
                opt.DefaultScheme = "Bearer";
                opt.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero 
                };
            });



            builder.Services.AddControllers();

            // Add AutoMapper
            builder.Services.AddAutoMapper(cfg => 
            {
                cfg.CreateMap<CreateVolunteerDTO, Voluntree>();
                cfg.CreateMap<CreateEventDTO, LavEvent>();
                cfg.CreateMap<LavEvent, GetEventDTO>();
                //cfg.CreateMap<IEnumerable<LavEvent>, IEnumerable<GetEventDTO>>();
                //organization
                cfg.CreateMap<CreateOrganizationDTO, Organization>();
            });

            builder.Services.AddScoped<IVolunteerService, VolunteerService>();
            builder.Services.AddScoped<LavenderSpiritAPI.Services.IEventService, LavenderSpiritAPI.Services.EventService>();
            builder.Services.AddScoped<IEventTrackerService, EventTrackerService>();
            //organization service
            builder.Services.AddScoped<IOrganizationService, OrganizationService>();

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


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();


            app.MapControllers();

            app.Run();
        }
    }
}
