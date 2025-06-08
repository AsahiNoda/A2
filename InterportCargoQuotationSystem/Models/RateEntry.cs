namespace InterportCargoQuotationSystem.Models
{
    public class RateEntry
    {
        public string Origin { get; set; } = "";
        public string Destination { get; set; } = "";
        public string ContainerType { get; set; } = "";
        public decimal Price { get; set; }
    }
}
