using Portfolio_Tracker_API.DTO;
using Portfolio_Tracker_API.Models;
using Portfolio_Tracker_API.Repositories;

namespace Portfolio_Tracker_API.Services
{
 public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly ITransactionRepository _transactionRepository;

        public InvestmentService(IInvestmentRepository investmentRepository,
            ITransactionRepository transactionRepository)
        {
            _investmentRepository = investmentRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<List<InvestmentDto>> GetUserInvestmentsAsync(int userId)
        {
            var investments = await _investmentRepository.GetByUserIdAsync(userId);
            return investments.Select(i => new InvestmentDto
            {
                Id = i.Id,
                Name = i.Name,
                Coin = i.Coin,
                Amount = i.Amount,
                PurchasePrice = i.PurchasePrice,
                PurchaseDate = i.PurchaseDate,
                AssetType = i.AssetType
            }).ToList();
        }

        public async Task<InvestmentDto> CreateInvestmentAsync(int userId, CreateInvestmentDto dto)
        {
            var investment = new Investment
            {
                UserId = userId,
                Name = dto.Name,
                Coin = dto.Coin,
                Amount = dto.Amount,
                PurchasePrice = dto.PurchasePrice,
                PurchaseDate = dto.PurchaseDate,
                AssetType = dto.AssetType
            };

            await _investmentRepository.AddAsync(investment);
            await _investmentRepository.SaveAsync();

            return new InvestmentDto
            {
                Id = investment.Id,
                Name = investment.Name,
                Coin = investment.Coin,
                Amount = investment.Amount,
                PurchasePrice = investment.PurchasePrice,
                PurchaseDate = investment.PurchaseDate,
                AssetType = investment.AssetType
            };
        }

        public async Task<InvestmentDto> UpdateInvestmentAsync(int investmentId, CreateInvestmentDto dto)
        {
            var investment = await _investmentRepository.GetByIdAsync(investmentId);
            if (investment == null)
                throw new Exception("Investment not found");

            investment.Name = dto.Name;
            investment.Amount = dto.Amount;
            investment.PurchasePrice = dto.PurchasePrice;

            await _investmentRepository.UpdateAsync(investment);
            await _investmentRepository.SaveAsync();

            return new InvestmentDto
            {
                Id = investment.Id,
                Name = investment.Name,
                Coin = investment.Coin,
                Amount = investment.Amount,
                PurchasePrice = investment.PurchasePrice,
                PurchaseDate = investment.PurchaseDate,
                AssetType = investment.AssetType
            };
        }

        public async Task DeleteInvestmentAsync(int investmentId)
        {
            await _investmentRepository.DeleteAsync(investmentId);
            await _investmentRepository.SaveAsync();
        }

        public async Task<PortfolioSummaryDto> GetPortfolioSummaryAsync(int userId)
        {
            var investments = await _investmentRepository.GetByUserIdAsync(userId);

            var summary = new PortfolioSummaryDto
            {
                Investments = investments.Select(i => new InvestmentDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Coin = i.Coin,
                    Amount = i.Amount,
                    PurchasePrice = i.PurchasePrice,
                    PurchaseDate = i.PurchaseDate,
                    AssetType = i.AssetType
                }).ToList()
            };

            decimal totalValue = 0;
            var allocations = new Dictionary<string, decimal>();

            foreach (var investment in investments)
            {
                decimal investmentValue = investment.Amount * investment.PurchasePrice;
                totalValue += investmentValue;

                if (allocations.ContainsKey(investment.Coin))
                    allocations[investment.Coin] += investmentValue;
                else
                    allocations[investment.Coin] = investmentValue;
            }

            summary.TotalValue = totalValue;
            summary.AssetAllocations = allocations.Select(a => new AssetAllocationDto
            {
                Coin = a.Key,
                Value = a.Value,
                Percentage = totalValue > 0 ? (a.Value / totalValue) * 100 : 0
            }).ToList();

            return summary;
        }
    }
}
