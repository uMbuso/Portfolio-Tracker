namespace Portfolio_Tracker_API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int InvestmentId { get; set; }
        public string Process { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public Investment Investment { get; set; }
    }
}
