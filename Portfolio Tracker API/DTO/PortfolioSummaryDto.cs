namespace Portfolio_Tracker_API.DTO
{
    public class PortfolioSummaryDto
    {
        public decimal TotalValue { get; set; }
        public List<AssetAllocationDto> AssetAllocations { get; set; }
        public List<InvestmentDto> Investments { get; set; }
    }
}
