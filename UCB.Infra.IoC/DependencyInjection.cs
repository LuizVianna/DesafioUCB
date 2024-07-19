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
using UCB.Infra.Data.Context;

namespace UCB.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseInMemoryDatabase(configuration.GetConnectionString("DefaultConnection"),
                //    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            service.AddAuthentication(
                    opt =>
                    {
                        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(option =>
                    {
                        option.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = configuration["jwt:issuer"],
                            ValidAudience = configuration["jwt:audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(
                                                Encoding.UTF8.GetBytes(configuration["jwt:secretkey"])),
                            ClockSkew = TimeSpan.Zero
                        };
                    });


            //service.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Repositories
            //service.AddScoped<IPedidoRepository, PedidoRepository>();
            //service.AddScoped<IItemRepository, ItemRepository>();
            //service.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Services
            //service.AddScoped<IItemService, ItemService>();
            //service.AddScoped<IPedidoService, PedidoService>();
            //service.AddScoped<IUsuarioService, UsuarioService>();
            //service.AddScoped<IAuthenticate, AuthenticateService>();

            return service;
        }
    }
}
