namespace Portfolio_Tracker_API.DTO
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int InvestmentId { get; set; }
        public string Process { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
