using UCB.Domain.Entities;

namespace UCB.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SelecionarTodosAsync();
        Task<User> SelecionarAsync(int id);
        Task<User> Incluir(User user);
        Task<User> Alterar(User user);
        Task<User> Excluir(int id);
    }
}
