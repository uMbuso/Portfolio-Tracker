namespace Portfolio_Tracker_API.DTO
{
    public class CreateTransactionDto
    {
        public int InvestmentId { get; set; }
        public string Process { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
    }
}
