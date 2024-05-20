namespace PizzaOrderingAPI.Models.DTOs
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}
