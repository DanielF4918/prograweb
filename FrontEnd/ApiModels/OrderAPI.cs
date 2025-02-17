namespace FrontEnd.APIModels
{
    public class OrderAPI
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShipVia { get; set; }
    }
}
