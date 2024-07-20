using UCB.Application.DTOs;
using UCB.Domain.Entities;

namespace UCB.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> SelecionarTodosAsync();
        Task<StudentDTO> SelecionarAsync(int id);
        Task<StudentDTO> Incluir(StudentDTO student);
        Task<StudentDTO> Alterar(StudentDTO student);
        Task<StudentDTO> Excluir(int id);
    }
}
