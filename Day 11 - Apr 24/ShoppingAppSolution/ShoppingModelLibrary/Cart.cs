using System.Collections.Generic;

namespace ShoppingModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public double Discount { get; set; }
        public int ShippingCharge { get; set; }
    }
}
