using Microsoft.AspNetCore.Mvc;
using UBC.Application.DTOs;
using UBC.Application.Interfaces;

namespace UCB.Api.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _usuarioService;

        public AuthenticationController(ITokenService tokenService, IUserService usuarioService)
        {
            _tokenService = tokenService;
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            if (loginDTO == null) return BadRequest("Email e/ou senha inválido!");

            if (string.IsNullOrEmpty(loginDTO.UserName) && string.IsNullOrEmpty(loginDTO.Password))
                return BadRequest("Email e/ou senha não podem ser vazios ou nulos!");

            //COMPARAR COM A SENHA CRIPTOGRAFADA DO BANCO
            var ehCorreta = _usuarioService.SenhaEhIgual(loginDTO);
            if (!ehCorreta)
                return BadRequest("Email e/ou senha inválido!");

            var novaSenha = _usuarioService.CriptografaSenha(loginDTO.Password);

            loginDTO.Password = novaSenha;
            var token = _tokenService.GenerateToken(loginDTO);
            if (token == string.Empty) return Unauthorized();


            return Ok(token);
        }

        
    }
}
