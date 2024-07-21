using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UBC.Application.DTOs;
using UBC.Application.Interfaces;
using UBC.Domain.Interfaces;

namespace UBC.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        private readonly IUserRepository _usuarioRepository;


        public TokenService(IConfiguration configuration, IUserRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        public  string GenerateToken(LoginDTO loginDTO)
        {

            var usuarioDataBase = _usuarioRepository.ObterPorUserName(loginDTO.UserName);
            if (loginDTO.UserName != usuarioDataBase.UserName 
                || loginDTO.Password != usuarioDataBase.Password)
            {
                return string.Empty;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signiCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer = issuer,
                audience = audience,
                claims: new[]
                {
                    new Claim("id", usuarioDataBase.Id.ToString()),
                    new Claim(type: ClaimTypes.Email, usuarioDataBase.UserName.ToLower()),
                },
                expires: DateTime.Now.AddDays(2),
                signingCredentials: signiCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
