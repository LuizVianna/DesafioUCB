using Microsoft.AspNetCore.Mvc;
using UCB.Application.DTOs;
using UCB.Application.Interfaces;

namespace UCB.Api.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("adiciona-student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> Incluir(StudentDTO studentDto)
        {
            if (string.IsNullOrEmpty(studentDto.Nome)
                || string.IsNullOrEmpty(studentDto.NomeMae))
                return BadRequest("Nome do student não pode ser nulo!");

            //var userId = User.GetId();
            //var usuarioLogado = await _usuarioService.ObterPorIdAsync(userId);

            //if (usuarioLogado == null) return BadRequest("Para incluir um sistema é necessário estar logado no sistema!");

            //sistemaDto.LoginUsuarioLogado = usuarioLogado.Email;

            await _studentService.Incluir(studentDto);

            return Ok("Sistema incluso com sucesso!");
        }

        [HttpDelete("delete-sistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Excluir(int id)
        {
            if (id <= 0)
                return BadRequest("Id não deve ser 0 ou negativo!");

            //var userId = User.GetId();
            //var usuarioLogado = await _usuarioService.ObterPorIdAsync(userId);
            // if (!usuarioLogado.IsAdmin) return Unauthorized("Você não tem permissão para excluir Sistemas!");

            var studentDTOExcluido = await _studentService.Excluir(id);
            if (studentDTOExcluido == null) return BadRequest("Ocorreu um erro ao excluir student!");

            return Ok("student excluído com sucessso!");
        }


        [HttpPut("atualizar-sstudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> Atualizar(StudentDTO dto)
        {
            if (dto == null)
                return BadRequest("O student não pode ser null!");

            //var userId = User.GetId();
            //var usuarioLogado = await _usuarioService.ObterPorIdAsync(userId);

            //if (usuarioLogado == null)
            //  return BadRequest("O usuário precisa estar logado na aplicação para realizar a operação!");

            //sistemaDto.LoginUsuarioLogado = usuarioLogado.Email;
            // Chama o serviço de troca de senha de usuário
            return await _studentService.Alterar(dto);
        }

        [HttpGet("lista-student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<StudentDTO>> SelecionarTodos()
        {
            return await _studentService.SelecionarTodosAsync();
        }

        [HttpGet("selecionar-sistema")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SelecionarPorId(int id)
        {
            if (id <= 0) return BadRequest("Id não deve ser 0 ou negativo!");

            var studentDTOSelecionado = await _studentService.SelecionarAsync(id);
            if (studentDTOSelecionado == null) return BadRequest("Id do sistema inexistente!");

            return Ok(studentDTOSelecionado);
        }
    }
}
