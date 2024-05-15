using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Models.DTOs;

namespace PizzaOrderingAPI.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(OrderDto orderDto);
    }
}
