using UBC.Application.DTOs;

namespace UBC.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Incluir(UserDTO objeto);

        Task<UserDTO> Excluir(int id);

        UserDTO ObterPorEmail(string login);

        Task<UserDTO> ObterPorIdAsync(int id);

        bool EmailExiste(UserDTO usuarioDto);

        string CriptografaSenha(string senha);

        Task<IEnumerable<UserDTO>> SelecionarTodosAsync();

        Task<UserDTO> SelecionarPorId(int id);

        bool SenhaEhIgual(LoginDTO usuarioDto);
    }
}
