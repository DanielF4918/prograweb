namespace FrontEnd.ApiModels
{
    public class ShipperAPI
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string? Phone { get; set; }
    }
}