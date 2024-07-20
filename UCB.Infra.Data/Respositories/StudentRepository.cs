using Microsoft.EntityFrameworkCore;
using UCB.Domain.Entities;
using UCB.Domain.Interfaces;
using UCB.Infra.Data.Context;

namespace UCB.Infra.Data.Respositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Alterar(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Excluir(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student> Incluir(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> SelecionarAsync(int id)
        {
            return await _context.Students.AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Student>> SelecionarTodosAsync()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
