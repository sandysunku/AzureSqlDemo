namespace AzureSqlXamarinAppDemoBackened.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
