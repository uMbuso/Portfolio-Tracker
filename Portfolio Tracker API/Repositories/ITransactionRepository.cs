using Portfolio_Tracker_API.Models;

namespace Portfolio_Tracker_API.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetByInvestmentIdAsync(int investmentId);
        Task<List<Transaction>> GetByUserIdAsync(int userId);
        Task<Transaction> GetByIdAsync(int id);
        Task AddAsync(Transaction transaction);
        Task SaveAsync();
    }
}
