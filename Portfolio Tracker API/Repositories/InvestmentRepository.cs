using Microsoft.EntityFrameworkCore;
using Portfolio_Tracker_API.Data;
using Portfolio_Tracker_API.Models;

namespace Portfolio_Tracker_API.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly PortfolioContext _context;

        public InvestmentRepository(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<List<Investment>> GetByUserIdAsync(int userId)
        {
            return await _context.Investments
                .Where(i => i.UserId == userId)
                .Include(i => i.Transactions)
                .ToListAsync();
        }

        public async Task<Investment> GetByIdAsync(int id)
        {
            return await _context.Investments
                .Include(i => i.Transactions)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(Investment investment)
        {
            await _context.Investments.AddAsync(investment);
        }

        public async Task UpdateAsync(Investment investment)
        {
            _context.Investments.Update(investment);
        }

        public async Task DeleteAsync(int id)
        {
            var investment = await GetByIdAsync(id);
            if (investment != null)
            {
                _context.Investments.Remove(investment);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
