using Portfolio_Tracker_API.DTO;

namespace Portfolio_Tracker_API.Services
{
    public interface IInvestmentService
    {
        Task<List<InvestmentDto>> GetUserInvestmentsAsync(int userId);
        Task<InvestmentDto> CreateInvestmentAsync(int userId, CreateInvestmentDto dto);
        Task<InvestmentDto> UpdateInvestmentAsync(int investmentId, CreateInvestmentDto dto);
        Task DeleteInvestmentAsync(int investmentId);
        Task<PortfolioSummaryDto> GetPortfolioSummaryAsync(int userId);
    }
}
