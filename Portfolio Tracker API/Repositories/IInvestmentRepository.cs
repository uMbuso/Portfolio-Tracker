using Portfolio_Tracker_API.Models;

namespace Portfolio_Tracker_API.Repositories
{
    public interface IInvestmentRepository
    {
        Task<List<Investment>> GetByUserIdAsync(int userId);
        Task<Investment> GetByIdAsync(int id);
        Task AddAsync(Investment investment);
        Task UpdateAsync(Investment investment);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
