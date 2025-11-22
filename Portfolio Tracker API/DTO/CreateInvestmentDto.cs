namespace Portfolio_Tracker_API.DTO
{
    public class CreateInvestmentDto
    {
        public string Name { get; set; }
        public string Coin { get; set; }
        public decimal Amount { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string AssetType { get; set; }
    }
}
