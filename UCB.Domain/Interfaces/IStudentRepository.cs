using UCB.Domain.Entities;

namespace UCB.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> SelecionarTodosAsync();
        Task<Student> SelecionarAsync(int id);
        Task<Student> Incluir(Student student);
        Task<Student> Alterar(Student student);
        Task<Student> Excluir(int id);
    }
}
