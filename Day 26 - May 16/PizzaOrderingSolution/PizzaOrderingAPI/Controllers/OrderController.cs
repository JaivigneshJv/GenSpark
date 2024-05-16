using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Models.DTOs;

namespace PizzaOrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            await _orderService.CreateOrder(orderDto);
            return Ok(orderDto);
        }
    }
}
