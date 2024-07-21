using AutoMapper;
using UBC.Application.DTOs;
using UBC.Application.Interfaces;
using UBC.Domain.Entities;
using UCB.Domain.Interfaces;

namespace UCB.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IMapper mapper, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDTO> Alterar(StudentDTO dto)
        {
            var student = await _studentRepository.SelecionarAsync(dto.Id);
            student.Alterar(dto.Id, dto.Nome, dto.Idade, dto.Serie, dto.NotaMedia, dto.Endereco, dto.NomePai, dto.NomeMae, dto.DataNascimento);
            await _studentRepository.Alterar(student);
            return dto;
        }

        public async Task<StudentDTO> Excluir(int id)
        {
            if (id < 0) return null;

            var student = await _studentRepository.SelecionarAsync(id);
            if (student != null)
                await _studentRepository.Excluir(student.Id);

            return _mapper.Map<StudentDTO>(student);

            return null;
        }

        public async Task<StudentDTO> Incluir(StudentDTO dto)
        {
            try
            {
                var student = new Student(dto.Id, dto.Nome, dto.Idade
                                         , dto.Serie, dto.NotaMedia, dto.Endereco
                                         , dto.NomePai, dto.NomeMae, dto.DataNascimento);

                await _studentRepository.Incluir(student);
                return _mapper.Map<StudentDTO>(student);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<StudentDTO> SelecionarAsync(int id)
        {
            var student = await _studentRepository.SelecionarAsync(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<IEnumerable<StudentDTO>> SelecionarTodosAsync()
        {
            var student = await _studentRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(student).ToList();
        }
    }
}
