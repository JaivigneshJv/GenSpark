using PizzaOrderingAPI.Contexts;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Models.DTOs;

namespace PizzaOrderingAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly PizzaOrderingContext _context;

        public OrderService(PizzaOrderingContext context)
        {
            _context = context;
        }

        public async Task<OrderDto> CreateOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                UserId = orderDto.UserId,
                PizzaId = orderDto.PizzaId,
                Quantity = orderDto.Quantity
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return orderDto;
        }
    }
}
