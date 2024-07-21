using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UBC.Application.Interfaces;
using UBC.Application.Mappings;
using UBC.Application.Services;
using UBC.Domain.Interfaces;
using UBC.Infra.Data.Context;
using UBC.Infra.Data.Respositories;
using UCB.Application.Services;
using UCB.Domain.Interfaces;
using UCB.Infra.Data.Respositories;

namespace UCB.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
        };
    });
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            service.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Repositories
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddScoped<IUserRepository, UserRepository>();

            //Services
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ITokenService, TokenService>();

            return service;
        }
    }
}
