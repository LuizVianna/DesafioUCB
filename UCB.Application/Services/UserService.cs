using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using UBC.Application.DTOs;
using UBC.Application.Interfaces;
using UBC.Domain.Entities;
using UBC.Domain.Interfaces;

namespace UCB.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Excluir(int id)
        {
            if (id < 0) return null;

            var usuario = await _userRepository.SelecionarAsync(id);
            if (usuario != null)
                await _userRepository.Excluir(usuario.Id);

            return _mapper.Map<UserDTO>(usuario);

            return null;
        }

        public async Task<UserDTO> Incluir(UserDTO dto)
        {
            try
            {
                var user = new User(dto.UserName, dto.Password);
                await _userRepository.Incluir(user);
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserDTO ObterPorEmail(string userName)
        {
            var usuario = _userRepository.ObterPorUserName(userName);
            return _mapper.Map<UserDTO>(usuario);
        }

        public async Task<UserDTO> ObterPorIdAsync(int id)
        {
            var usuario = await _userRepository.SelecionarAsync(id);
            return _mapper.Map<UserDTO>(usuario);
        }

        public bool SenhaEhIgual(LoginDTO usuarioDto)
        {
            var usuarioBaseDados = _userRepository.ObterPorUserName(usuarioDto.UserName);

            if (usuarioBaseDados == null) return false;

            var criptoSenha = CriptografaSenha(usuarioDto.Password);

            if (criptoSenha != usuarioBaseDados.Password) return false;

            return true;
        }

        public bool EmailExiste(UserDTO usuarioDto)
        {
            var usuarioBaseDados = _userRepository.ObterPorUserName(usuarioDto.UserName);

            if (usuarioBaseDados == null) return false;

            return true;
        }


        public string CriptografaSenha(string senha)
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public async Task<IEnumerable<UserDTO>> SelecionarTodosAsync()
        {
            var usuarios = await _userRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(usuarios).ToList();
        }

        public async Task<UserDTO> SelecionarPorId(int id)
        {
            var usuario = await _userRepository.SelecionarAsync(id);
            return _mapper.Map<UserDTO>(usuario);
        }

        //TODO: Realizar Logout no sistema

    }
}
