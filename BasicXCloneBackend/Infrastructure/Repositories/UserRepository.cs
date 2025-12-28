using Microsoft.EntityFrameworkCore;
using BasicXCloneBackend.Domain.Entities;
using BasicXCloneBackend.Domain.Interfaces;

namespace BasicXCloneBackend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> IsUserValid(string userName)
        {
            var exists = await _context.User
                .AnyAsync(u => u.UserName == userName);

            return exists;
        }

    }
}

