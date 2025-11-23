using Portfolio_Tracker_API.Models;

namespace Portfolio_Tracker_API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task SaveAsync();
    }
}
