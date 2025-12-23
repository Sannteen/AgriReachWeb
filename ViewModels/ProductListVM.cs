namespace AgriReachWeb.ViewModels
{
    public class ProductListVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string FarmName { get; set; }

        public string AvailabilityStatus { get; set; }
    }
}
