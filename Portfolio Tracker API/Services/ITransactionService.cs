using Portfolio_Tracker_API.DTO;

namespace Portfolio_Tracker_API.Services
{
    public interface ITransactionService
    {
        Task<List<TransactionDto>> GetUserTransactionsAsync(int userId);
        Task<TransactionDto> CreateTransactionAsync(CreateTransactionDto dto);
    }
}
