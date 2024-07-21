using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCB.Application.Interfaces;
using UCB.Application.Mappings;
using UCB.Application.Services;
using UCB.Domain.Interfaces;
using UCB.Infra.Data.Context;
using UCB.Infra.Data.Respositories;

namespace UCB.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            //service.AddAuthentication(
            //        opt =>
            //        {
            //            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //        }).AddJwtBearer(option =>
            //        {
            //            option.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidateLifetime = true,
            //                ValidateIssuerSigningKey = true,

            //                ValidIssuer = configuration["jwt:issuer"],
            //                ValidAudience = configuration["jwt:audience"],
            //                IssuerSigningKey = new SymmetricSecurityKey(
            //                                    Encoding.UTF8.GetBytes(configuration["jwt:secretkey"])),
            //                ClockSkew = TimeSpan.Zero
            //            };
            //        });


            service.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Repositories
            service.AddScoped<IStudentRepository, StudentRepository>();
            //service.AddScoped<IItemRepository, ItemRepository>();
            //service.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Services
            service.AddScoped<IStudentService, StudentService>();
            //service.AddScoped<IPedidoService, PedidoService>();
            //service.AddScoped<IUsuarioService, UsuarioService>();
            //service.AddScoped<IAuthenticate, AuthenticateService>();

            return service;
        }
    }
}
