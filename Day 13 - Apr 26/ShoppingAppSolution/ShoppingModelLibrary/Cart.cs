﻿

namespace ShoppingModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}