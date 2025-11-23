using Microsoft.EntityFrameworkCore;
using Portfolio_Tracker_API.Data;
using Portfolio_Tracker_API.Models;

namespace Portfolio_Tracker_API.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PortfolioContext _context;

        public TransactionRepository(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetByInvestmentIdAsync(int investmentId)
        {
            return await _context.Transactions
                .Where(t => t.InvestmentId == investmentId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetByUserIdAsync(int userId)
        {
            return await _context.Transactions
                .Include(t => t.Investment)
                .Where(t => t.Investment.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .Include(t => t.Investment)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
