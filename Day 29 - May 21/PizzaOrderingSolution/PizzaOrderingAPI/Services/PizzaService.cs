using Microsoft.EntityFrameworkCore;
using PizzaOrderingAPI.Contexts;
using PizzaOrderingAPI.Interfaces;
using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Exceptions;

namespace PizzaOrderingAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly PizzaOrderingContext _context;

        public PizzaService(PizzaOrderingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pizza>> GetPizzasInStock()
        {
            return await _context.Pizzas
                .Where(p => p.InStock)
                .Select(p => new Pizza
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    InStock = p.InStock
                })
                .ToListAsync();
        }
        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                throw new PizzaNotFoundException();
            }
            return pizza;
        }

        public async Task<List<Pizza>> GetAllPizzas()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza> UpdatePizza(int id, Pizza updatedPizza)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                throw new PizzaNotFoundException();
            }
            pizza.Name = updatedPizza.Name;
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task DeletePizza(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                throw new PizzaNotFoundException();
            }
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
        }
        public async Task<Pizza> GetPizzaByName(string name)
        {
            return await _context.Pizzas.FirstOrDefaultAsync(p => p.Name.ToLower().Contains(name.ToLower()));
        }

    }
}
