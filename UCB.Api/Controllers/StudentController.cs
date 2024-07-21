using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UBC.Application.DTOs;
using UBC.Application.Interfaces;


namespace UCB.Api.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _usuarioService;

        public StudentController(IStudentService studentService, IUserService usuarioService)
        {
            _studentService = studentService;
            _usuarioService = usuarioService;
        }

        [HttpGet("list-all-students")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<StudentDTO>> SelecionarTodos()
        {
            return await _studentService.SelecionarTodosAsync();
        }

        [HttpPost("add-student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> Incluir(StudentDTO studentDto)
        {
            if (string.IsNullOrEmpty(studentDto.Nome)
                || string.IsNullOrEmpty(studentDto.NomeMae))
                return BadRequest("Nome do student não pode ser nulo!");

            await _studentService.Incluir(studentDto);

            return Ok("Student incluso com sucesso!");
        }

        [HttpDelete("delete-student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Excluir(int id)
        {
            if (id <= 0)
                return BadRequest("Id não deve ser 0 ou negativo!");

            var studentDTOExcluido = await _studentService.Excluir(id);
            if (studentDTOExcluido == null) return BadRequest("Ocorreu um erro ao excluir student!");

            return Ok("student excluído com sucessso!");
        }


        [HttpPut("update-student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> Atualizar(StudentDTO dto)
        {
            if (dto == null) return BadRequest("O student não pode ser null!");
            return await _studentService.Alterar(dto);
        }



        [HttpGet("select-student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SelecionarPorId(int id)
        {
            if (id <= 0) return BadRequest("Id não deve ser 0 ou negativo!");

            var studentDTOSelecionado = await _studentService.SelecionarAsync(id);
            if (studentDTOSelecionado == null) return BadRequest("Id do student inexistente!");

            return Ok(studentDTOSelecionado);
        }
    }
}
