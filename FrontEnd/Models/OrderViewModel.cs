namespace FrontEnd.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShipVia { get; set; }
    }
}
