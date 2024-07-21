using Microsoft.EntityFrameworkCore;
using UBC.Domain.Entities;
using UBC.Domain.Interfaces;
using UBC.Infra.Data.Context;



namespace UBC.Infra.Data.Respositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Alterar(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Excluir(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User> Incluir(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> SelecionarAsync(int id)
        {
            return await _context.Users.AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> SelecionarTodosAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public User ObterPorUserName(string userName)
        {
            return _context.Users
                                 .AsNoTracking()
                                 .FirstOrDefault(x => x.UserName == userName);
        }
    }
}
