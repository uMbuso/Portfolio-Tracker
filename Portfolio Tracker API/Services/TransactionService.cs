using Portfolio_Tracker_API.DTO;
using Portfolio_Tracker_API.Models;
using Portfolio_Tracker_API.Repositories;

namespace Portfolio_Tracker_API.Services
{
        public class TransactionService : ITransactionService
        {
            private readonly ITransactionRepository _transactionRepository;
            private readonly IInvestmentRepository _investmentRepository;

            public TransactionService(ITransactionRepository transactionRepository,
                IInvestmentRepository investmentRepository)
            {
                _transactionRepository = transactionRepository;
                _investmentRepository = investmentRepository;
            }

            public async Task<List<TransactionDto>> GetUserTransactionsAsync(int userId)
            {
                var transactions = await _transactionRepository.GetByUserIdAsync(userId);
                return transactions.Select(t => new TransactionDto
                {
                    Id = t.Id,
                    InvestmentId = t.InvestmentId,
                    Process = t.Process,
                    Amount = t.Amount,
                    Price = t.Price,
                    Date = t.Date
                }).ToList();
            }

            public async Task<TransactionDto> CreateTransactionAsync(CreateTransactionDto dto)
            {
                var transaction = new Transaction
                {
                    InvestmentId = dto.InvestmentId,
                    Process = dto.Process,
                    Amount = dto.Amount,
                    Price = dto.Price,
                    Date = DateTime.UtcNow
                };

                await _transactionRepository.AddAsync(transaction);
                await _transactionRepository.SaveAsync();

                return new TransactionDto
                {
                    Id = transaction.Id,
                    InvestmentId = transaction.InvestmentId,
                    Process = transaction.Process,
                    Amount = transaction.Amount,
                    Price = transaction.Price,
                    Date = transaction.Date
                };
            }
        }
}
