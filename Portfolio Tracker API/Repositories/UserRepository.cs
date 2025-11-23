using Microsoft.EntityFrameworkCore;
using Portfolio_Tracker_API.Data;
using Portfolio_Tracker_API.Models;

namespace Portfolio_Tracker_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PortfolioContext _context;

        public UserRepository(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.Investments)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
