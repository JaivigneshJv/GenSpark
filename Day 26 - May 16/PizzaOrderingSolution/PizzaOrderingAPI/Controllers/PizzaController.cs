using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaOrderingAPI.Exceptions;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Models.DTOs;

namespace PizzaOrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("/GetPizzasInStock")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzasInStock()
        {
            var pizzas = await _pizzaService.GetPizzasInStock();
            return Ok(pizzas);
        }
        [HttpPost("/AddPizza")]
        public async Task<ActionResult<Pizza>> CreatePizza(Pizza pizza)
        {
            try
            {
                var newPizza = await _pizzaService.CreatePizza(pizza);
                return CreatedAtAction(nameof(GetPizzaById), new { id = newPizza.Id }, newPizza);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizzaById(int id)
        {
            try
            {
                var pizza = await _pizzaService.GetPizzaById(id);
                return Ok(pizza);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/GetAll")]
        public async Task<ActionResult<List<Pizza>>> GetAllPizzas()
        {
            return await _pizzaService.GetAllPizzas();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePizza(int id, Pizza pizza)
        {
            try
            {
                await _pizzaService.UpdatePizza(id, pizza);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetPizzaByName")]
        public async Task<ActionResult<Pizza>> GetPizzaByName(string name)
        {
            var pizza = await _pizzaService.GetPizzaByName(name);
            if (pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePizza(int id)
        //{
        //    try
        //    {
        //        await _pizzaService.DeletePizza(id);
        //        return NoContent();
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
    }
}
