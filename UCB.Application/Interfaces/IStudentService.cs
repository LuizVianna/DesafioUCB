using UBC.Application.DTOs;


namespace UBC.Application.Interfaces
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
